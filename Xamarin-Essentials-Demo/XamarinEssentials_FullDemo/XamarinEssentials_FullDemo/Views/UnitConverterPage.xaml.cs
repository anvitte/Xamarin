using Xamarin.Forms;
using Xamarin.Essentials;
using XamarinEssentials_FullDemo.ViewModels;
using System;

namespace XamarinEssentials_FullDemo.Views
{
    public partial class UnitConverterPage : ContentPage
    {
        UnitConverterPageViewModel objUnitConverterViewModel;
        public UnitConverterPage()
        {
            InitializeComponent();
            this.BindingContext = objUnitConverterViewModel = new UnitConverterPageViewModel();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(e.OldTextValue!=null)
            {
                return;
            }
            if (e.NewTextValue != null)
            {
                double textValue=Convert.ToInt64(e.NewTextValue);
                objUnitConverterViewModel.ConvertToKilometer.Execute(textValue);

            }
        }
    }
}
