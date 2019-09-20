using Prism;
using Prism.Ioc;
using XamarinEssentials_FullDemo.ViewModels;
using XamarinEssentials_FullDemo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinEssentials_FullDemo.Services;
using XamarinEssentials_FullDemo.Interfaces;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinEssentials_FullDemo
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            containerRegistry.RegisterForNavigation<PrismMasterDetailPage, PrismMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<AppInformationPage, AppInformationPageViewModel>();
            containerRegistry.RegisterForNavigation<ConnectivityInformationPage, ConnectivityInformationPageViewModel>();

            containerRegistry.RegisterForNavigation<FileSystemTabPage, FileSystemTabPageViewModel>();
            containerRegistry.RegisterForNavigation<NewContactPage, NewContactPageViewModel>();
            containerRegistry.RegisterForNavigation<ContactsDetailsPage, ContactsDetailsPageViewModel>();


            //Services
            containerRegistry.RegisterSingleton<ILocalPhoneDB,PhoneLocalDB> ();
        }
    }
}
