using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ElementosEmergentes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            b1.Clicked += B1_Clicked; 
            b2.Clicked += B2_Clicked;
            b3.Clicked += B3_Clicked;

        }

        private void B3_Clicked(object sender, EventArgs e)
        {
            PedirPermiso();
        }

        private void B2_Clicked(object sender, EventArgs e)
        {
            MuestraOpciones();
        }

        private void B1_Clicked(object sender, EventArgs e)
        {
            AvisoAsync();
        }
        public async Task AvisoAsync()
        {
            await DisplayAlert("Control Alert", "Aviso de espera", "OK");
        }

        public async Task PedirPermiso()
        {
            bool respuesta = await DisplayAlert("Titulo", "¿Quiere jugar?", "Si", "No");
        }

        public async Task MuestraOpciones()
        {
            string action = await DisplayActionSheet("Acciones", "¿Dónde quiere ir?", "Cancelar",
                null, "Email", "Instagram", "Facebook");
        }
    }
}
