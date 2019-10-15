using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinEssentials_FullDemo.Interfaces;
using XamarinEssentials_FullDemo.Models;

namespace XamarinEssentials_FullDemo.ViewModels
{
    public class MyNotesPageViewModel : ViewModelBase
    {
        //Toolbar Isvisible button states
        private bool _saveItemButton=false;
        public bool SaveItemButton
        {
            get { return _saveItemButton; }
            set { SetProperty(ref _saveItemButton, value); }
        }
        private bool _newItemButton=true;
        public bool NewItemButton
        {
            get { return _saveItemButton; }
            set { SetProperty(ref _newItemButton, value); }
        }


        //File
        private const string _defaultFile = "MyNotes.txt";
        private static string FileName = String.Empty;

        //path
        private string _defaultFilePath = Path.Combine("notes", _defaultFile);
        private string _notePath = "notes";

        //
        private List<FileSystemModel> _lstFileNames;
        public List<FileSystemModel> LstFilesNames
        {
            get { return _lstFileNames; }
            set { SetProperty(ref _lstFileNames, value); }
        }
        //Content
        private string _defaultContent;
        public string DefaultContent
        {
            get { return _defaultContent; }
            set
            {
                SetProperty(ref _defaultContent, value);
            }

        }

        //private string _customContent;
        //public string CustomContent
        //{
        //    get => _customContent;
        //    set => SetProperty(ref _customContent, value);
        //}

        //Delegate Commands
        public DelegateCommand<string> LoadNotes;
        public DelegateCommand<string> EnableSaveButton;
        public DelegateCommand<string> SaveExisitngNotes { get; set; }
        public DelegateCommand<string> DeleteNote;
        public DelegateCommand CreateNote;

        public DelegateCommand<object> NoteItemSelected;



        //Prism Service
        private IPageDialogService _dialogService;


        //Contructor

        public MyNotesPageViewModel()
        {
            Title = "Notes";
            LoadNotes = new DelegateCommand<string>(LoadFiles);
            CreateNote = new DelegateCommand(CreateNewNote);
            DeleteNote = new DelegateCommand<string>(DeleteExistingNote);

            SaveExisitngNotes = new DelegateCommand<string>(SaveExistingNote);
            EnableSaveButton = new DelegateCommand<string>(SaveButtonEnable);
            NoteItemSelected = new DelegateCommand<object>(ItemSelected);

            //  LoadFiles(
            GetAllNotes();
        }

        private void SaveButtonEnable(string newEditorValue)
        {
            SetProperty(ref _saveItemButton, true);
            SetProperty(ref _defaultContent, newEditorValue);
           
            RaisePropertyChanged("SaveItemButton");

        }

        public MyNotesPageViewModel(IPageDialogService dialogService)
        {
            _dialogService = dialogService;

        }


        private void ItemSelected(object itemSelected)
        {
            var item = itemSelected as FileSystemModel;
            if (!string.IsNullOrEmpty(item.NoteName))
            {
                LoadFiles(Convert.ToString(item.NoteName));
            }
        }

        public void GetAllNotes()
        {
            try
            {

                _lstFileNames = Xamarin.Forms.DependencyService.Get<IAssestFilesLoader>().GetAllFilesName(FileSystem.AppDataDirectory);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public  async void SaveExistingNote(string newContent)
        {
            //File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory,"notes/MyNotes.txt"), newContent);
            //using (var stream = await FileSystem.OpenAppPackageFileAsync("notes/MyNotes.txt"))
            //using (var writter = new StreamWriter(stream))
            //{
            //    stream.wr
            //    writter.WriteLine(newContent);
            //    SetProperty(ref _saveItemButton, false);
            //    RaisePropertyChanged("DefaultContent");
            //}
        }

        private void DeleteExistingNote(string noteName)
        {
            if (File.Exists(_notePath))
            {
                File.Delete(_notePath);
            }
        }


        private void CreateNewNote()
        {
            Random rx = new Random();
            int numberFile = rx.Next(100000);
            FileName = string.Format("MyNotes", numberFile, ".txt");

            if (!File.Exists(_defaultFilePath))
            {
                using (var writter = new StreamWriter(_defaultFilePath, true))
                {
                    writter.WriteLine(_defaultContent);
                    RaisePropertyChanged("DefaultContent");
                }

            }
        }

        private void LoadFiles(string fileName)
        {
            FileName = fileName;

            if (String.IsNullOrEmpty(FileName))
            {
                ReadFile(_defaultFilePath);
            }
            else
            {
                _notePath = Path.Combine(_notePath, FileName);
                ReadFile(_notePath);
            }
        }

        public async void ReadFile(string path)
        {


            using (var stream = await FileSystem.OpenAppPackageFileAsync(path))
            using (var reader = new StreamReader(stream))
            {
                _defaultContent = await reader.ReadToEndAsync();
                RaisePropertyChanged("DefaultContent");
            }
        }

    }


}

