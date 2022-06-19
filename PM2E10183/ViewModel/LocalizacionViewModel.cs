using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PM2E10183.ViewModel
{
    public class LocalizacionViewModel: Models.LocalizacionModel
    {
        private string error;
        public string Error { get { return error; }  set { error = value;OnPropertyChanged(); } }
        public Command LocalizameCommand { get; set; }
        public LocalizacionViewModel()
        {
            LocalizameCommand = new Command(Localizar);
        }
        private async void Localizar()
        {
            try
            {
                var localizacion = await Geolocation.GetLastKnownLocationAsync();
                if (localizacion == null)
                {
                    localizacion = await Geolocation.GetLocationAsync(
                        new GeolocationRequest()
                        {
                            DesiredAccuracy = GeolocationAccuracy.Default,
                            Timeout = TimeSpan.FromSeconds(5)
                        });
                }
                if (localizacion == null )
                {
                    Error = "Localizacion desconocida";

                }
                else
                {
                    Longitud = localizacion.Longitude;
                    Latitiud = localizacion.Latitude;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace); ;
            }
        }
    }
}
