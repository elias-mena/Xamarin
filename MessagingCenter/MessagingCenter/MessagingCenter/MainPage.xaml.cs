using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MessagingCenter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<Page1>(this, "Hola", async (s) =>
            {
                await DisplayAlert("Saludo","Hola")
            });
        }
        private async void Oncliked(object sender, EventArgs e)
        {
            var result = await DisplayActionSheet("Opciones", "Ok", null, new[] {"Colombia",
            "México", "Costa Rica"});

            await DisplayAlert("Saludo", "Hola" + result, "Aceptar");
        }
    }
}
