using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace XamarinEssentials_FullDemo.ViewModels
{
    public class ConnectivityInformationPageViewModel : BindableBase
    {

        //Add Permission in android manifest - "Access Network State" not required in iOS and UWP
        // <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />

        //Commands
        public DelegateCommand CheckConnectivityCommand { get; set; }
        public DelegateCommand CheckProfiles { get; set; }
        //Properties
        IEnumerable<ConnectionProfile> profiles;
        NetworkAccess objNetworkAccess;

        //Services
        private IPageDialogService _dialogService;

        public ConnectivityInformationPageViewModel(IPageDialogService dialogService)
        {
            _dialogService = dialogService;
            CheckConnectivityCommand = new DelegateCommand(CheckInternetConnectivity);
            CheckProfiles = new DelegateCommand(GetProfiles);
            profiles = Connectivity.ConnectionProfiles;
            objNetworkAccess = Connectivity.NetworkAccess;
            Connectivity.ConnectivityChanged += ConnectivityChanged;
        }

        private void GetProfiles()
        {
            StringBuilder messageBuilder = new StringBuilder();
           
            if (profiles.Count()>0)
            {
                foreach (var item in profiles)
                {
                    messageBuilder.Append(item + "\n");
                }
                _dialogService.DisplayAlertAsync("Profiles", messageBuilder.ToString(), "Ok");
            }
            else
            {
                _dialogService.DisplayAlertAsync("Profiles","No profiles found", "Ok");
            }

        }

        private void ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            StringBuilder messageBuilder = new StringBuilder();
            profiles = e.ConnectionProfiles;
            foreach (var item in profiles)
            {
                messageBuilder.Append("Profiles :"+item+"\n");
            }
            objNetworkAccess = e.NetworkAccess;
            messageBuilder.Append("Network :" + objNetworkAccess);
            _dialogService.DisplayAlertAsync("Changed Status",messageBuilder.ToString() , "Ok");
            messageBuilder.Clear();
        }

        private void CheckInternetConnectivity()
        {
            Tuple<string,string> result = CheckConnectivity();
            _dialogService.DisplayAlertAsync(result.Item1, result.Item2, "Ok");
        }

        public Tuple<string, string> CheckConnectivity()
        {

            if (objNetworkAccess == NetworkAccess.Internet)
            {
                return Tuple.Create("Internet", Constants.NetworkConnectivityConstants.Internet);

            }
            else if (objNetworkAccess == NetworkAccess.ConstrainedInternet)
            {
                return Tuple.Create("Constrained Internet", Constants.NetworkConnectivityConstants.ConstrainedInternet);

            }
            else if (objNetworkAccess == NetworkAccess.Local)
            {
                return Tuple.Create("Local", Constants.NetworkConnectivityConstants.Local);

            }
            else if (objNetworkAccess == NetworkAccess.None)
            {
                return Tuple.Create("None", Constants.NetworkConnectivityConstants.None);

            }
            else
            {
                return Tuple.Create("Unknown", Constants.NetworkConnectivityConstants.Unknown);

            }
        }


    }
}
