using CardfileDotNet.Data;
using CardfileDotNet.Localization;
using CardfileDotNet.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CardfileDotNet.UI
{
    public partial class CardViewUserControl : LocalizableUserControl, ICommitable
    {
        private const int CardOffsetX = 25;
        private const int CardOffsetY = 20;
        private int ViewCardCount = 0;
        private List<CardUserControl> cardControls;

        public WindowState State { get; } = null;

        public CardViewUserControl(WindowState state)
        {
            InitializeComponent();
            State = state;
            cardControls = new List<CardUserControl>();
            State.BindFile(GotFile);
            this.Resize += (s, e) => OnResize();
            this.DoubleBuffered = true;
            FullLayout();
            OptionHandler.OptionsUpdated += (s, e) => {
                foreach (CardUserControl uc in cardControls)
                    uc.ResizeTo(OptionHandler.CardWidth, OptionHandler.CardHeight);
                FullCardMove();
            };
        }

        private void GotFile(Cardfile file)
        {
            FullLayout();
            file.CardsChanged += (s, e) =>
            {
                switch (e.ListChangedType)
                {
                    case ListChangedType.Reset:
                        FullLayout();
                        break;
                    case ListChangedType.ItemAdded:
                        OnItemAdded(e.NewIndex);
                        break;
                    case ListChangedType.ItemDeleted:
                        OnItemDeleted(e.NewIndex);
                        break;
                    case ListChangedType.ItemMoved:
                        OnItemMoved(e.OldIndex, e.NewIndex);
                        break;
                }
            };
            file.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "FrontIndex")
                    FullCardAssign();
            };
        }

        private void DoCardMove(int i)
        {
            CardUserControl card = cardControls[i];
            card.Left = (i + 1) * CardOffsetX;
            card.Top = this.Height - ((i + 1) * CardOffsetY) - card.Height;
            card.InBackground = i != 0;
        }

        private void FullCardMove()
        {
            int front = State.File.FrontIndex;
            int count = State.File.CardCount;
            this.SuspendLayout();
            for (int i = 0; i < Math.Min(count, ViewCardCount); ++i)
            {
                CardUserControl card = cardControls[i];
                card.SuspendLayout();
                DoCardMove(i);
                card.SendToBack();
                card.ResumeLayout();
            }
            this.ResumeLayout();
        }

        private void FullCardAssign()
        {
            int front = State.File.FrontIndex;
            int count = State.File.CardCount;
            for (int i = 0; i < Math.Min(count, ViewCardCount); ++i)
            {
                int j = (front + i) % count;
                if (cardControls[i].Card != State.File.Cards[j])
                    cardControls[i].Card = State.File.Cards[j];
            }
        }

        public int MaxCardsVisible => 4 + (this.Width / CardOffsetX);

        public void OnResize()
        {
            int newViewCardCount = MaxCardsVisible;
            for (int i = newViewCardCount; i < ViewCardCount; ++i)
                RemoveCardControl(newViewCardCount);
            for (int i = Math.Min(cardControls.Count, ViewCardCount); i < Math.Min(newViewCardCount, State.File.CardCount); ++i)
            {
                AddNewCardControl(i);
                DoCardMove(i);
            }
            ViewCardCount = newViewCardCount;
            FullCardAssign();
        }

        public void FullLayout()
        {
            int newViewCardCount = MaxCardsVisible;
            for (int i = cardControls.Count - 1; i >= State.File.CardCount; --i)
                RemoveCardControl(i);
            if (State.File.CardCount == 0)
                return;
            for (int i = newViewCardCount; i < ViewCardCount; ++i)
                RemoveCardControl(newViewCardCount);
            for (int i = Math.Min(cardControls.Count, ViewCardCount); i < Math.Min(newViewCardCount, State.File.CardCount); ++i)
                AddNewCardControl(i);
            ViewCardCount = newViewCardCount;
            FullCardMove();
            FullCardAssign();
        }

        private void AddNewCardControl(int i)
        {
            CardUserControl uc = new CardUserControl();
            uc.InBackground = false;
            uc.Card = null;
            uc.ResizeTo(OptionHandler.CardWidth, OptionHandler.CardHeight);
            uc.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom;
            uc.BackgroundClicked += (s, e) =>
            {
                if (s is CardUserControl c)
                {
                    State.File.BringUpCard(c.Card);
                    cardControls[0].Focus();
                    cardControls[0].FocusContentsBox();
                }
            };
            // hide initially
            uc.Top = this.Top + this.Height + 100;
            uc.Left = this.Left + this.Width + 100;
            cardControls.Insert(i, uc);
            this.Controls.Add(uc);
        }

        private void RemoveCardControl(int i)
        {
            if (i >= cardControls.Count)
                return;
            CardUserControl uc = cardControls[i];
            uc.Card = null;
            this.Controls.Remove(uc);
            cardControls.RemoveAt(i);
            uc.Dispose();
        }

        private void OnItemAdded(int index)
        {
            int front = State.File.FrontIndex;
            int count = State.File.CardCount;
            if (cardControls.Count < State.File.CardCount && cardControls.Count < ViewCardCount)
            {
                int newIndex = cardControls.Count;
                AddNewCardControl(newIndex);
                ++ViewCardCount;
                for (int i = index; i < Math.Min(count, ViewCardCount); ++i)
                    cardControls[i].Card = State.File.Cards[i];
                DoCardMove(newIndex);
                cardControls[newIndex].InBackground = newIndex > 0;
                return;
            }

            int first = front;
            int last = (front + ViewCardCount) % count;
            if ((first < last && (first <= index && index < last)) || (last < first && (first <= index || index < last)))
            {
                int startingControlIndex = index - first;
                if (startingControlIndex < 0)
                    startingControlIndex += State.File.CardCount;
                for (int i = startingControlIndex; i < Math.Min(count, ViewCardCount); ++i)
                    cardControls[i].Card = State.File.Cards[(index + i) % count];
                FullCardMove();
                FullCardAssign();
            }
        }

        private void OnItemDeleted(int index)
        {
            if (cardControls.Count < ViewCardCount)
            {
                RemoveCardControl(index);
            }

            FullCardAssign();
        }

        public void Commit()
        {
            if (cardControls.Count > 0)
                cardControls[0].Commit();
        }

        public void DoCut() => cardControls[0].DoCut();
        public void DoCopy() => cardControls[0].DoCopy();
        public void DoPaste() => cardControls[0].DoPaste();

        public int ContentsSelectionStart => cardControls.Count > 0 ? cardControls[0].ContentsSelectionStart : 0;
        public int ContentsSelectionLength => cardControls.Count > 0 ? cardControls[0].ContentsSelectionLength : 0;

        public void SelectText(int start, int length)
        {
            if (cardControls.Count > 0)
                cardControls[0].SelectText(start, length);
        }

        private void OnItemMoved(int oldIndex, int newIndex)
        {
            FullCardAssign();
        }

        internal void FocusIndexBox()
        {
            if (cardControls.Count > 0)
            {
                cardControls[0].Select();
                cardControls[0].FocusIndexBox();
            }
        }

        public override void Localize()
        {
        }
    }
}
