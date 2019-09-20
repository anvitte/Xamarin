using Xamarin.Forms;

namespace XamarinEssentials_FullDemo.Views
{
    public partial class FileSystemTabPage : TabbedPage
    {
        public FileSystemTabPage()
        {
            InitializeComponent();
            Children.Add(new NewContactPage());
            Children.Add(new ContactsDetailsPage());
        }
    }
}
