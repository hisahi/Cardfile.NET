using CardfileDotNet.Logic;
using CardfileDotNet.UI;
using System;
using System.ComponentModel;

namespace CardfileDotNet.Data
{
    public class WindowState : VolatileState
    {
        private Cardfile _file;
        private ViewMode _viewMode;
        private MainForm _form;

        public WindowState(MainForm form)
        {
            _form = form;
            File = new Cardfile();
            ViewMode = ViewMode.Card;
            BindFile(GotFile);
            this.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "ViewMode")
                    Update("Editing");
            };
        }

        public Cardfile File
        {
            get => _file;
            set => Set(ref _file, value);
        }
        public ViewMode ViewMode
        {
            get => _viewMode;
            set => Set(ref _viewMode, value);
        }
        public bool HasCards => File.CardCount > 0;
        public bool Editing => HasCards && (ViewMode == ViewMode.Card || ViewMode == ViewMode.Edit);
        public bool CanUndo => File.CanUndo;
        public bool CanRedo => File.CanRedo;
        public bool CanFindNext => File.CanFindNext;
        public bool CanExport => HasCards && File.FrontCard.Attachment != null;
        public int FrontCardIndex
        {
            get => File.FrontIndex;
            set => File.FrontIndex = value;
        }

        public void GotFile(Cardfile file)
        {
            Update("HasCards");
            Update("Editing");
            Update("CanUndo");
            Update("CanRedo");
            file.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "CardCount")
                {
                    Update("HasCards");
                    Update("Editing");
                }
                if (e.PropertyName == "CanUndo" || e.PropertyName == "CanRedo" || e.PropertyName == "CanFindNext")
                    Update(e.PropertyName);
            };
        }

        public void BindFile(Action<Cardfile> callback)
        {
            this.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "File")
                    callback(File);
            };
            callback(File);
        }

        public void BindFrontCard(Action<Card> callback)
        {
            Cardfile oldFile = null;
            PropertyChangedEventHandler BindCardListener = (s2, e2) =>
            {
                if (e2.PropertyName == "FrontCard")
                    callback(File.FrontCard);
            };
            BindFile((file) =>
            {
                if (oldFile != null)
                    oldFile.PropertyChanged -= BindCardListener;
                callback(file.FrontCard);
                file.PropertyChanged += BindCardListener;
                oldFile = file;
            });
        }

        public delegate void FileClosedEventHandler(object sender, FileClosedEventArgs e);
        // not used right now
        public event FileClosedEventHandler FileClosed;
    }

    public enum ViewMode
    {
        [Description("Card View. Displays all cards")]
        Card,
        [Description("Edit View. Displays one card in full screen")]
        Edit,
        [Description("File View. Displays the attached file in the current card")]
        File,
        [Description("List View. Displays all cards in a list")]
        List
    }

    public class FileClosedEventArgs : EventArgs
    {
        public Cardfile File { get; }

        public FileClosedEventArgs(Cardfile file)
        {
            File = file;
        }
    }
}
