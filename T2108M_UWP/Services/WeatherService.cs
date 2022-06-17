using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2108M_UWP.Models1;
using System.Net.Http;
using Newtonsoft.Json;
namespace T2108M_UWP.Services
{
    class WeatherService
    {
        public async Task<Forecast> GetCurrentWeather()
        {
            HttpClient client = new HttpClient();
            string url = "http://api.openweathermap.org/data/2.5/forecast?q=Saigon,vietnam&appid=09a71427c59d38d6a34f89b47d75975c&units=metric";
            /*string url = "http://api.openweathermap.org/data/2.5/forecast?q=London,England&appid=09a71427c59d38d6a34f89b47d75975c&units=metric";*/
            var rs = await client.GetAsync(url);
            if(rs.IsSuccessStatusCode)
            {
                var stringContent = await rs.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<Forecast>(stringContent);
            }
            return null;
        }
    }
}
