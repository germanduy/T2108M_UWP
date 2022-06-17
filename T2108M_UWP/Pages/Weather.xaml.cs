using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using T2108M_UWP.Services;
using T2108M_UWP.Models1;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T2108M_UWP.Pages 
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Weather : Page
    {
        public Weather()
        {
            this.InitializeComponent();
            PrintTemp();

        }
        public async void PrintTemp()
        {
           /* StudentList.Items.Add(new Student()
            {
                Id = 1,
                Name = "Le Duc Duy",
                Age = 22,
                Address = "addres 1"

            });*/
            


            WeatherService ws = new WeatherService();
            Forecast cw = await ws.GetCurrentWeather();

            for(int i = 0; i < 15; i++)
            {
                weatherlist.Items.Add(cw.list[i]);
                
            }
           



            // bacsic
            /*  Temp.Text = cw.city.name;
              Temp1.Text = cw.city.timezone.ToString();
              Temp2.Text = cw.city.population.ToString();
              Temp3.Text = cw.city.coord.ToString();*/

            // cach 1

            /*for (int i = 0; i < cw.list.Count; i++)
            {
                Console.WriteLine(cw.list[i].main.temp);
                Temp.Text = cw.city.name;
                Temp1.Text = cw.list[i].main.feels_like.ToString();
                Temp2.Text = cw.list[i].main.pressure.ToString();
                Temp3.Text = cw.list[i].main.sea_level.ToString();
                Temp4.Text = cw.list[i].main.temp.ToString();
            }*/

            //cach 2

            /*  foreach (List tt in cw.list)
              {
                  Console.WriteLine(tt.main.temp);
                  Temp.Text = cw.city.name;
                  Temp1.Text = tt.main.feels_like.ToString();
                  Temp2.Text = tt.main.pressure.ToString();
                  Temp3.Text = tt.main.sea_level.ToString();
                  Temp4.Text = tt.main.temp.ToString();
              }*/

        }



    }
    }
