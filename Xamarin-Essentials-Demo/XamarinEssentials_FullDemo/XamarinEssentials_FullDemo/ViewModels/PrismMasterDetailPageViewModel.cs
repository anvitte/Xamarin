using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinEssentials_FullDemo.ViewModels
{
	public class PrismMasterDetailPageViewModel : BindableBase
	{
        //Commands
        public DelegateCommand NavigateToAppInfoPage { get; set; }
        public DelegateCommand NavigateToConnectivityInfoPage { get; set; }
        public DelegateCommand NavigationToFileSystemPage { get; set; }

        //Navigation Service
        private  INavigationService _navigationService;
        public PrismMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeAllCommands();
        }

        private void InitializeAllCommands()
        {
            NavigateToAppInfoPage = new DelegateCommand(NavigateToAppInformationPage);
            NavigateToConnectivityInfoPage = new DelegateCommand(NavigateToConnectivityInformationPage);
            NavigationToFileSystemPage = new DelegateCommand(NavigateToFileSystemHelperPage);
        }

        private void NavigateToFileSystemHelperPage()
        {
            _navigationService.NavigateAsync("NavigationPage/FileSystemTabPage");
        }

        private void NavigateToAppInformationPage ()
        {
            _navigationService.NavigateAsync("NavigationPage/AppInformationPage");
        }

        private void NavigateToConnectivityInformationPage()
        {
            _navigationService.NavigateAsync("NavigationPage/ConnectivityInformationPage");
        }
    }
}
