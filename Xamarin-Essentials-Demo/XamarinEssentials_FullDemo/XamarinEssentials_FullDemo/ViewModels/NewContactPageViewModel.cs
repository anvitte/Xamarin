using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using XamarinEssentials_FullDemo.Interfaces;
using XamarinEssentials_FullDemo.Models;

using Prism.Services;

namespace XamarinEssentials_FullDemo.ViewModels
{
    public class NewContactPageViewModel : BindableBase
    {
        private string _name;
        private string _phoneNumber;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetProperty(ref _name, value);
            }
        }
        public string PhoneNumber { get { return _phoneNumber; } set { SetProperty(ref _phoneNumber, value); } }

        //Commands
        public DelegateCommand SaveContactInfo { get; set; }

        //Services
        ILocalPhoneDB _localDbService;
        IPageDialogService _dialogService;

        //Model
        PhoneDialerModel objContactInfo = null;
        public NewContactPageViewModel(ILocalPhoneDB serviceDB, IPageDialogService dialogService)
        {
            _localDbService = serviceDB;
            _dialogService = dialogService;
            objContactInfo = new PhoneDialerModel();
            SaveContactInfo = new DelegateCommand(SaveContactsDetails);
        }

        private async void SaveContactsDetails()
        {
            objContactInfo.Name = Name;
            objContactInfo.PhoneNumber = PhoneNumber;
            int result =await  _localDbService.InsertIntoContactTable(objContactInfo);
            _phoneNumber = string.Empty;
            _name = string.Empty;
            RaisePropertyChanged(PhoneNumber);
            RaisePropertyChanged(Name);

            if (result>0)
            {
                await _dialogService.DisplayAlertAsync("Successfull", "Contact Added Successfully ", "ok");
            }
            else
            {
                await _dialogService.DisplayAlertAsync("Error", "Error in adding the contact ", "ok");
            }

        }
    }
}
