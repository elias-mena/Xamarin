using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Catalogo
{

    public partial class MainPage : ContentPage
    {
        public IEnumerable<Producto> Products { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            // Cargamos los datos
            var data = new Data();
            // Asignamos Products a los products de la data
            Products = data.Products;
            // Enviamos el contexto
            BindingContext = this;
        }
        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            _ = e.Item as Producto;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _ = e.SelectedItem as Producto;
        }
    }
}
