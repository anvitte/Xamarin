using Xamarin.Forms;
using XamarinEssentials_FullDemo.ViewModels;

namespace XamarinEssentials_FullDemo.Views
{
    public partial class MyNotesPage : ContentPage
    {
        MyNotesPageViewModel objMyNotePageViewModel;
        public MyNotesPage()
        {
            InitializeComponent();
            this.BindingContext = objMyNotePageViewModel = new MyNotesPageViewModel();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
                objMyNotePageViewModel.NoteItemSelected.Execute(e.Item);
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.OldTextValue==null )
            {
                return;
            }
            if (e.NewTextValue != e.OldTextValue)
            {
                objMyNotePageViewModel.EnableSaveButton.Execute(e.NewTextValue);
            }
        }
    }
}
