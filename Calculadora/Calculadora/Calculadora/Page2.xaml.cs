using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculadora
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public IList<Operacion> History { get; private set; }
        public Page2(IList<Operacion> history)
        {
            InitializeComponent();
            btnReset.Clicked += BtnReset_Clicked;
            History = history;
            BindingContext = this;
        }

        private void BtnReset_Clicked(object sender, EventArgs e)
        {
            string nombreArchivo = "prueba.txt";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string rutaCompleta = Path.Combine(ruta, nombreArchivo);

            using (var escritor = File.CreateText(rutaCompleta))
            {
                History.Clear();
                escritor.WriteLine("");
                string mensaje = "Se ha borrado el historial";
                _ = AvisoAsync(mensaje);
            }
            // Volvemos a la página principal
            _ = Navigation.PopAsync();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            _ = e.Item as Operacion;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _ = e.SelectedItem as Operacion;
        }
        public async Task AvisoAsync(string mensaje)
        {
            await DisplayAlert("Aviso", mensaje, "OK");
        }
    }
}