using CardfileDotNet.IO;
using CardfileDotNet.Logic;
using CardfileDotNet.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CardfileDotNet.Data
{
    public class Cardfile : VolatileState
    {
        private string _filePath;
        private bool _unsaved;
        private bool _canSaveBack;
        private BindingList<Card> _cards;
        private UndoBuffer _undo;
        private FindRequest _find;
        private bool undoing;
        private int index;
        private string _restoreIndex;
        private string _restoreContents;
        private AttachmentFile _restoreAttachment;

        internal Cardfile()
        {
            FilePath = null;
            Unsaved = false;
            _undo = new UndoBuffer(this);
            _cards = new BindingList<Card>();
            _cards.RaiseListChangedEvents = true;
            _cards.ListChanged += Cards_ListChanged;
            _undo.StateChanged += Undo_StateChanged;
        }

        public static Cardfile NewFile()
        {
            Cardfile file = new Cardfile();
            file.AddCard(new Card(""));
            file.Unsaved = false;
            file.FrontIndex = 0;
            return file;
        }

        public string FilePath
        {
            get => _filePath;
            set => Set(ref _filePath, value);
        }
        public IReadOnlyList<Card> Cards => _cards;
        public bool Unsaved
        {
            get => _unsaved;
            set => Set(ref _unsaved, value);
        }
        public FindRequest Find
        {
            get => _find;
            set
            {
                Set(ref _find, value);
                Update(nameof(CanFindNext));
            }
        }

        public bool CanSaveBack
        {
            get => _canSaveBack;
            private set => _canSaveBack = value;
        }
        public bool CanUndo => _undo.CanUndo;
        public bool CanRedo => _undo.CanRedo;
        internal UndoBuffer UndoBuffer => _undo;
        public bool CanFindNext => _find != null;

        public int CardCount => Cards.Count;
        public int FrontIndex
        {
            get => CardCount <= 0 ? -1 : index = MathUtil.Remainder(index, CardCount);
            set
            {
                if (FrontIndex != value)
                {
                    if (Cards.Count > 0)
                        Set(ref index, MathUtil.Remainder(value, CardCount));
                    else
                        value = -1;
                    Update(nameof(FrontCard));
                    SetUpRestore();
                }
            }
        }

        public bool CompressFile { get; set; } = false;
        public Card FrontCard => CardCount > 0 ? Cards[FrontIndex] : null;

        public void NextCard() => ++FrontIndex;
        public void PreviousCard() => --FrontIndex;
        public void AddCard(Card card)
        {
            card.CardChanged += Card_CardChanged;
            _cards.Add(card);
            if (!undoing)
                _undo.OnCardAdded(_cards.Count - 1, card);
        }

        public void InsertCard(Card card)
        {
            int index = this.FrontIndex + 1;
            card.CardChanged += Card_CardChanged;
            _cards.Insert(index, card);
            if (!undoing)
                _undo.OnCardAdded(index, card);
        }

        public void InsertCardAt(int index, Card card)
        {
            card.CardChanged += Card_CardChanged;
            _cards.Insert(index, card);
            if (!undoing)
                _undo.OnCardAdded(index, card);
        }

        private void SetUpRestore()
        {
            _restoreIndex = FrontCard.Index;
            _restoreContents = FrontCard.Contents;
            _restoreAttachment = FrontCard.Attachment;
        }

        public void RestoreFrontCard()
        {
            if (FrontIndex < 0)
                return;
            if (!undoing)
                _undo.OnCardRestore(FrontCard);
            bool oldUndoing = undoing;
            undoing = true;
            FrontCard.Index = _restoreIndex;
            FrontCard.Contents = _restoreContents;
            FrontCard.Attachment = _restoreAttachment;
            undoing = oldUndoing;
        }

        public void ClearCard(int index)
        {
            Card card = _cards[index];
            if (!undoing)
                _undo.OnCardReset(card);
            bool oldUndoing = undoing;
            undoing = true;
            card.Clear();
            undoing = oldUndoing;
        }

        public Card RemoveCardAt(int index)
        {
            Card card = _cards[index];
            if (!undoing)
                _undo.OnCardRemoved(index, card);
            card.CardChanged -= Card_CardChanged;
            _cards.RemoveAt(index);
            return card;
        }

        private void Cards_ListChanged(object sender, ListChangedEventArgs e)
        {
            Update("CardCount");
            CardsChanged?.Invoke(sender, e);
            Unsaved = true;
        }

        private void Card_CardChanged(object sender, CardChangedEventArgs e)
        {
            Card card = sender as Card;
            if (!undoing)
            {
                if (e.PropertyName == "Index")
                    _undo.OnCardIndexChanged(card, e.OldValue as string, e.NewValue as string);
                else if (e.PropertyName == "Contents")
                    _undo.OnCardContentsChanged(card, e.OldValue as string, e.NewValue as string);
                else if (e.PropertyName == "Attachment")
                    _undo.OnCardAttachmentChanged(card, e.OldValue as AttachmentFile, e.NewValue as AttachmentFile);
            }
        }

        private void Undo_StateChanged(object sender, EventArgs e)
        {
            Update("CanUndo");
            Update("CanRedo");
        }

        public static Cardfile Open(string filePath, FileFormat format)
        {
            bool compressed = false;
            Cardfile file = new Cardfile();
            file.FilePath = filePath;

            switch (format)
            {
                case FileFormat.CRDX:
                    new CrdxDecoder().Read(file, filePath, out compressed);
                    break;
                case FileFormat.CRD:
                    new CrdDecoder().Read(file, filePath);
                    break;
            }

            file.CompressFile = compressed;
            file.CanSaveBack = format == FileFormat.CRDX;
            file.Unsaved = false;
            return file;
        }

        internal void Merge(string path, FileFormat fmt)
        {
            Cardfile another = Open(path, fmt);
            foreach (Card c in another.Cards)
                this.AddCard(c);
        }

        public void Save()
        {
            if (FilePath == null)
                throw new ArgumentNullException();
            new CrdxEncoder().Write(this, FilePath, CompressFile);
            CanSaveBack = true;
            Unsaved = false;
        }

        public void Save(string fileName, bool compress)
        {
            FilePath = fileName;
            CompressFile = compress;
            Save();
        }

        public void Undo()
        {
            undoing = true;
            _undo.Undo();
            undoing = false;
        }

        public void Redo()
        {
            undoing = true;
            _undo.Redo();
            undoing = false;
        }

        internal void BringUpCard(Card card)
        {
            FrontIndex = _cards.IndexOf(card);
        }

        internal void BringUpCardEdit(Card card)
        {
            BringUpCard(card);
            // TODO: access MainState and bring up 
        }

        internal void BringUpCardAttachment(Card card)
        {
            BringUpCard(card);

        }

        public event ListChangedEventHandler CardsChanged;
    }

    public enum FileFormat
    {
        [Description(".CRDX; native Cardfile.NET format.")]
        CRDX,
        [Description(".CRD; original Windows Cardfile format.")]
        CRD
    }
}
