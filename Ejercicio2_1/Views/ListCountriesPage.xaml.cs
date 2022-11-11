using Ejercicio2_1.Models;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListCountriesPage : ContentPage
    {
        private string region = null;
        private int index;
        public ListCountriesPage()
        {
            InitializeComponent();
            LoadCountries();
        }

        public ListCountriesPage(int selectedIndex, string regionSelected)
        {
            InitializeComponent();
            region = regionSelected;
            index = selectedIndex;
            LoadCountries();
        }

        /*protected override void OnAppearing()
        {
            base.OnAppearing();            
            
        }*/

        private async void LoadCountries()
        {
            var InternetAccess = Connectivity.NetworkAccess;
            if (InternetAccess == NetworkAccess.Internet)
            {
                List<Country> listCountries = new List<Country>();
                listCountries = await Controllers.CountriesController.getCountries(index, region);                
                lvCountries.ItemsSource = listCountries;
            }            
        }

        private async void lvCountries_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var country = (Country)e.Item;
            var lat = country.latlng[0];
            var lng = country.latlng[1];
            string labelPin = country.translations.es;

            var popupPage = new ShowCountry(lat,lng, labelPin);
            popupPage.BindingContext = country;

            var scaleAnimation = new ScaleAnimation
            {
                PositionIn = MoveAnimationOptions.Right,
                PositionOut = MoveAnimationOptions.Left
            };

            popupPage.Animation = scaleAnimation;
            await PopupNavigation.Instance.PushAsync(popupPage);
        }
    }
}