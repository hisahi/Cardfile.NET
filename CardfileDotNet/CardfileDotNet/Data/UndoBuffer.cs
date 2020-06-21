using System;

namespace CardfileDotNet.Data
{
    internal class UndoBuffer
    {
        private const int UndoSize = 500;
        private Cardfile file;
        private LimitedStack<UndoAction> undo;
        private LimitedStack<UndoAction> redo;

        public UndoBuffer(Cardfile cardfile)
        {
            this.file = cardfile;
            this.undo = new LimitedStack<UndoAction>(UndoSize);
            this.redo = new LimitedStack<UndoAction>(UndoSize);
        }

        private void OnStateChanged()
        {
            StateChanged?.Invoke(this, new EventArgs());
        }

        public void ClearUndo()
        {
            undo.Clear();
            redo.Clear();
        }

        public void Undo()
        {
            if (CanUndo)
            {
                var action = undo.Pop();
                redo.Push(action);
                UndoAction(action);
                OnStateChanged();
            }
        }

        public void Redo()
        {
            if (CanRedo)
            {
                var action = redo.Pop();
                undo.Push(action);
                RedoAction(action);
                OnStateChanged();
            }
        }

        public void QueueAction(UndoAction action)
        {
            undo.Push(action);
            redo.Clear();
            OnStateChanged();
        }

        public void OnCardAdded(int cardIndex, Card addedCard)
        {
            QueueAction(new UndoAction(UndoActionType.AddedCard, cardIndex, addedCard));
        }

        public void OnCardIndexChanged(Card card, string oldValue, string newValue)
        {
            QueueAction(new UndoAction(UndoActionType.ChangedCardIndex, card, oldValue));
        }

        public void OnCardContentsChanged(Card card, string oldValue, string newValue)
        {
            QueueAction(new UndoAction(UndoActionType.ChangedCardContents, card, oldValue));
        }

        public void OnCardAttachmentChanged(Card card, AttachmentFile oldValue, AttachmentFile newValue)
        {
            QueueAction(new UndoAction(UndoActionType.ChangedCardAttachment, card, oldValue));
        }

        public void OnCardRemoved(int cardIndex, Card removedCard)
        {
            QueueAction(new UndoAction(UndoActionType.RemovedCard, cardIndex, removedCard));
        }

        public void OnCardRestore(Card resetCard)
        {
            QueueAction(new UndoAction(UndoActionType.CardReset, resetCard, resetCard.Index, resetCard.Contents, resetCard.Attachment));
        }

        public void OnCardReset(Card resetCard)
        {
            QueueAction(new UndoAction(UndoActionType.CardReset, resetCard, resetCard.Index, resetCard.Contents, resetCard.Attachment));
        }

        private void UndoAction(UndoAction action)
        {
            Card card;
            switch (action.Action)
            {
                case UndoActionType.AddedCard:
                    action.Data2 = file.RemoveCardAt((int)action.Data1);
                    break;
                case UndoActionType.ChangedCardIndex:
                    card = action.Data1 as Card;
                    card.Index = action.SwapData2(card.Index) as string;
                    file.BringUpCard(card);
                    break;
                case UndoActionType.ChangedCardContents:
                    card = action.Data1 as Card;
                    card.Contents = action.SwapData2(card.Contents) as string;
                    file.BringUpCard(card);
                    break;
                case UndoActionType.ChangedCardAttachment:
                    card = action.Data1 as Card;
                    card.Attachment = action.SwapData2(card.Attachment) as AttachmentFile;
                    file.BringUpCardAttachment(card);
                    break;
                case UndoActionType.RemovedCard:
                    file.InsertCardAt((int)action.Data1, action.Data2 as Card);
                    break;
                case UndoActionType.CardReset:
                    card = action.Data1 as Card;
                    card.Index = action.SwapData2(card.Index) as string;
                    card.Contents = action.SwapData3(card.Contents) as string;
                    card.Attachment = action.SwapData4(card.Index) as AttachmentFile;
                    break;
            }
        }

        private void RedoAction(UndoAction action)
        {
            Card card;
            switch (action.Action)
            {
                case UndoActionType.AddedCard:
                    file.InsertCardAt((int)action.Data1, action.Data2 as Card);
                    break;
                case UndoActionType.ChangedCardIndex:
                    card = action.Data1 as Card;
                    card.Index = action.SwapData2(card.Index) as string;
                    file.BringUpCard(card);
                    break;
                case UndoActionType.ChangedCardContents:
                    card = action.Data1 as Card;
                    card.Contents = action.SwapData2(card.Contents) as string;
                    file.BringUpCard(card);
                    break;
                case UndoActionType.ChangedCardAttachment:
                    card = action.Data1 as Card;
                    card.Attachment = action.SwapData2(card.Attachment) as AttachmentFile;
                    file.BringUpCardAttachment(card);
                    break;
                case UndoActionType.RemovedCard:
                    file.RemoveCardAt((int)action.Data1);
                    break;
                case UndoActionType.CardReset:
                    card = action.Data1 as Card;
                    card.Index = action.SwapData2(card.Index) as string;
                    card.Contents = action.SwapData3(card.Contents) as string;
                    card.Attachment = action.SwapData4(card.Index) as AttachmentFile;
                    break;
            }
        }

        public bool CanUndo => !undo.Empty;
        public bool CanRedo => !redo.Empty;

        public event EventHandler StateChanged;
    }

    public class UndoAction
    {
        internal UndoActionType Action;
        internal object Data1;
        internal object Data2;
        internal object Data3;
        internal object Data4;

        public UndoAction(UndoActionType action, Card card)
        {
            this.Action = action;
            this.Data1 = card;
        }

        public UndoAction(UndoActionType action, int index, Card card)
        {
            this.Action = action;
            this.Data1 = index;
            this.Data2 = card;
        }

        public UndoAction(UndoActionType action, Card card, string text)
        {
            this.Action = action;
            this.Data1 = card;
            this.Data2 = text;
        }

        public UndoAction(UndoActionType action, Card card, AttachmentFile file)
        {
            this.Action = action;
            this.Data1 = card;
            this.Data2 = file;
        }

        public UndoAction(UndoActionType action, Card card, string index, string contents, AttachmentFile file)
        {
            this.Action = action;
            this.Data1 = card;
            this.Data2 = index;
            this.Data3 = contents;
            this.Data4 = file;
        }

        public object SwapData2(object newValue)
        {
            object oldValue = Data2;
            Data2 = newValue;
            return oldValue;
        }

        public object SwapData3(object newValue)
        {
            object oldValue = Data3;
            Data2 = newValue;
            return oldValue;
        }

        public object SwapData4(object newValue)
        {
            object oldValue = Data4;
            Data2 = newValue;
            return oldValue;
        }
    }

    public enum UndoActionType
    {
        AddedCard,
        ChangedCardIndex,
        ChangedCardContents,
        ChangedCardAttachment,
        RemovedCard,
        CardReset
    }
}
