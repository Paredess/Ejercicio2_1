using Ejercicio2_1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio2_1
{
    public partial class MainPage : ContentPage
    {
        private string regionSelected = null;
        private int selectedIndex;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;            
            selectedIndex = picker.SelectedIndex;
            //var region = (string)picker.ItemsSource[selectedIndex];
            //if (selectedIndex != -1)

            switch (selectedIndex)
            {
                case 0:
                    regionSelected = "NAFTA";
                    imgRegion.Source = "aNorte.png";
                    break;
                case 1:
                    regionSelected = "CAIS";
                    imgRegion.Source = "aCentral.png";
                    break;
                case 2:
                    regionSelected = "USAN";
                    imgRegion.Source = "aSur.png";
                    break;
                case 3:
                    regionSelected = "europe";
                    imgRegion.Source = "eu.png";
                    break;
                case 4:
                    regionSelected = "africa";
                    imgRegion.Source = "africa.png";
                    break;
                case 5:
                    regionSelected = "asia";
                    imgRegion.Source = "asia.png";
                    break;
                case 6:
                    regionSelected = "oceania";
                    imgRegion.Source = "oceania.png";
                    break;
                default:
                    regionSelected = "";
                    imgRegion.Source = "";                    
                    break;
            }
            
        }

        private async void btnBuscar_Clicked(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(region))
            if (selectedIndex != -1)           
            {
                ListCountriesPage page = new ListCountriesPage(selectedIndex, regionSelected);
                page.BindingContext = regionSelected;
                await Navigation.PushAsync(page);
            }
            else
            {
                await DisplayAlert("Aviso", "Elija una región", "SI");
            }
            
        }
    }
}
