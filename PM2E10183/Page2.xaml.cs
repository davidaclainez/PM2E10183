using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E10183
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2(string imagen, string latitud, string longitud, string descripcion)
        {
            InitializeComponent();
            txtImagen.Text = imagen;
            txtDescripcion.Text = descripcion;

        }

        private async void btnShare_Clicked(object sender, EventArgs e)
        {
            byte[] Base64Stream = Convert.FromBase64String(txtImagen.Text);

            var source = ImageSource.FromStream(() => new MemoryStream(Base64Stream));
            await Share.RequestAsync(new ShareFileRequest
            {
                Title = txtDescripcion.Text
            }) ;
        }
    }
}