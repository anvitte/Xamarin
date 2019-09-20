using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using XamarinEssentials_FullDemo.Interfaces;
using XamarinEssentials_FullDemo.Models;

namespace XamarinEssentials_FullDemo.ViewModels
{
    public class ContactsDetailsPageViewModel : BindableBase
    {
        private List<PhoneDialerModel> _LstContacts;

        //Command
        public DelegateCommand<object> ItemTappedCommand { get; set; }
        public List<PhoneDialerModel> LstContacts
        {
            get { return _LstContacts; }
            set
            {
                SetProperty(ref _LstContacts, value);
            }
        }
       
        //Services
        ILocalPhoneDB _phoneLocalDb;
        public ContactsDetailsPageViewModel(ILocalPhoneDB _serviceContact)
        {
            _phoneLocalDb = _serviceContact;
            ItemTappedCommand = new DelegateCommand<object>(OnPhoneNumberSelected);
           
            _LstContacts = _phoneLocalDb.GetAllContactNumbers();
        }

        private void OnPhoneNumberSelected(object obj)
        {
           var selecteditem= obj as PhoneDialerModel;
            PhoneDialer.Open(selecteditem.PhoneNumber);
        }
    }
}
