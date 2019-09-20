using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace XamarinEssentials_FullDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand NavigateToMasterPage { get; set; }
        INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            _navigationService = navigationService;
            NavigateToMasterPage = new DelegateCommand(OnClickStartButton);
        }

        private void OnClickStartButton()
        {
            _navigationService.NavigateAsync($"PrismMasterDetailPage/NavigationPage/AppInformationPage");
        }
    }
}
