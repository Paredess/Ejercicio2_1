using Ejercicio2_1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_1.Controllers
{
    public static class CountriesController
    {
        public async static Task<List<Country>> getCountries(int index, string region)
        {
            string url = "";
            
            if (index < 3)
            {
                url = "https://restcountries.com/v2/regionalbloc/";
            }
            else
            {                
                url = "https://restcountries.com/v2/region/";
            }
            try
            {
                List<Country> countriesList = new List<Country>();

                using (HttpClient cliente = new HttpClient())
                {
                    var respuesta = await cliente.GetAsync(url + region);
                    if (respuesta.IsSuccessStatusCode)
                    {
                        var contenido = respuesta.Content.ReadAsStringAsync().Result;
                        countriesList = JsonConvert.DeserializeObject<List<Country>>(contenido);
                    }
                }                
                return countriesList;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }        
    }
}
