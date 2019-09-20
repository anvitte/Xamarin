using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using XamarinEssentials_FullDemo.Models;

namespace XamarinEssentials_FullDemo.ViewModels
{
	public class AppInformationPageViewModel : BindableBase
	{
        //Model Initialization
        AppInfomationModel objAppInfoModel { get; set; }

        //Properties 
        public string AppNameLabel { get; set; }
        public string AppName { get; set; }
        public string AppPackageNameLabel { get; set; }
        public string AppPackageName { get; set; }
        public string AppPackageVersionLabel { get; set; }
        public string AppPackageVersion { get; set; }
        public String AppBuildLabel { get; set; }
        public string AppBuild { get; set; }
        public string AppShowSettingUILabel { get; set; }

        //Commands
        public DelegateCommand ShowSettingUICommand { get; set; }
        public AppInformationPageViewModel()
        {

            objAppInfoModel = new AppInfomationModel();
            ShowSettingUICommand = new DelegateCommand(ShowSettingUI);
            LoadAppInfomation();

        }

        private void ShowSettingUI()
        {
            AppInfo.ShowSettingsUI();
        }

        private void LoadAppInfomation()
        {
            objAppInfoModel.AppNameLabel = AppNameLabel=Constants.AppInfomationConstants.AppNameLabel;
            objAppInfoModel.AppName = AppName =AppInfo.Name;
            objAppInfoModel.AppPackageNameLabel = AppPackageNameLabel= Constants.AppInfomationConstants.AppPackageNameLabel;
            objAppInfoModel.AppPackageName = AppPackageName= AppInfo.PackageName;
            objAppInfoModel.AppPackageVersionLabel = AppPackageVersionLabel= Constants.AppInfomationConstants.AppPackageVersionLabel;
            objAppInfoModel.AppPackageVersion = AppPackageVersion= AppInfo.VersionString;
            objAppInfoModel.AppBuildLabel =AppBuildLabel= Constants.AppInfomationConstants.AppBuildLabel;
            objAppInfoModel.AppBuild =AppBuild= AppInfo.BuildString;
            objAppInfoModel.AppShowSettingUI = AppShowSettingUILabel = Constants.AppInfomationConstants.AppShowSettingUILabel;
        }
    }
}
