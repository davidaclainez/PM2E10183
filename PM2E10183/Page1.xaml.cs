using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E10183
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            llenarDatos();
        }

        public async void llenarDatos()
        {
            var sitiosList = await App.SQLiteDB.GetSitiosAsync();
            if (sitiosList != null)
            {
                lstSitios.ItemsSource = sitiosList;
            }
        }

        private async void lstSitios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Models.Sitios)e.SelectedItem;
            var sitio = await App.SQLiteDB.GetSitiosById(obj.ID);
            if (sitio != null) {
                txtIdSitio.Text = sitio.First().ID.ToString();
            }
            bool respuesta = await DisplayAlert("Accion", "Desea ir a la ubicacion indicada", "Si","No");
            if (respuesta)
            {
                await Navigation.PushAsync(new Page2());
            }

            
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var sitio = await App.SQLiteDB.GetSitiosById(Convert.ToInt32(txtIdSitio.Text));
            if (sitio != null && !string.IsNullOrEmpty(txtIdSitio.Text))
            {
                await App.SQLiteDB.DeleteSitioAsync(sitio.First());
                await DisplayAlert("Sitio", "Se elimino de manera exitosa", "Ok");
                llenarDatos();
            }
        }
    }
}