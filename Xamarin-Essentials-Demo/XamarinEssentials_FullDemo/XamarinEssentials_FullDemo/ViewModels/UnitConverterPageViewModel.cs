using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
namespace XamarinEssentials_FullDemo.ViewModels
{
    public class UnitConverterPageViewModel : BindableBase

    { 

        private string _kilometers;

        public string Kilometers
        {
            get { return _kilometers; }
            set
            {
                SetProperty(ref _kilometers, value);

            }
        }
        public DelegateCommand<object> ConvertToKilometer { get; set; }
        public UnitConverterPageViewModel()
        {
            ConvertToKilometer = new DelegateCommand<object>(ToKilometers);
        }

        private void ToKilometers(object Miles)
        {
            _kilometers = UnitConverters.MilesToKilometers(Convert.ToDouble(Miles)).ToString();
             RaisePropertyChanged("Kilometers");
        }

      


    }
}
