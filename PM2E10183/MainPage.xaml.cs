using PM2E10183.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using PM2E10183.Models;
using System.IO;

namespace PM2E10183
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LocalizacionViewModel();
        }
        
        async void btnImagen_Clicked(System.Object sender, System.EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions {
                Title = "Seleccione"
            });
            if (result != null)
            {
                
                var stream = await result.OpenReadAsync();

                using (MemoryStream memory = new MemoryStream())
                {
                    stream.CopyTo(memory);
                    byte[] bytes = memory.ToArray();
                    resultImage.Source = ImageSource.FromStream(() => new MemoryStream(bytes));
                    string base64 = System.Convert.ToBase64String(bytes);
                    base64Imagen.Text =base64;
                }
            }
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (validar())
            {
                Sitios sitios = new Sitios
                {
                    Longitud = txtLongitud.Text,
                    Latitud = txtLatitud.Text,
                    Descripcion = txtDescripcion.Text,
                    Imagen = base64Imagen.Text
                };
                await App.SQLiteDB.GuardarSitio(sitios);
                txtLongitud.Text = "";
                txtLatitud.Text = "";
                txtDescripcion.Text = "";
                resultImage.Source = null;
                await DisplayAlert("Registro", "Se guardo correctamente el sitio", "OK");

            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "OK");
                
            }

        }
        public bool validar()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtLatitud.Text) || string.IsNullOrEmpty(txtLongitud.Text) || string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(resultImage.ToString()))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private void btnLista_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1());
        }
    }
}
