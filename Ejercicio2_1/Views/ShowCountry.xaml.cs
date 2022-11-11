using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowCountry : PopupPage
    {
        private double Lat, Lng;
        private string lblPin;
        public ShowCountry()
        {
            InitializeComponent();
        }
        public ShowCountry(double lat, double lng, string pinLabel)
        {
            InitializeComponent();
            Lat = lat;
            Lng = lng;
            lblPin = pinLabel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var pin = new Pin()
                {
                    Position = new Position(Lat, Lng),
                    Label = lblPin
                };
                mapSiteLocation.Pins.Add(pin);
                mapSiteLocation.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Lat, Lng), Distance.FromMeters(100.00)));                
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}