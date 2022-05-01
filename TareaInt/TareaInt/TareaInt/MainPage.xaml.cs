using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TareaInt.Model;

namespace TareaInt
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BtnGuardar.Clicked += BtnGuardar_Clicked;
            BtnLeer.Clicked += BtnLeer_Clicked;
            BtnLimpiar.Clicked += BtnLimpiar_Clicked1;

        }

        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            DatoRepository.Instancia.AddNewData(txtInfo.Text, int.Parse(txtLevel.Text));
            lblMensaje.Text = DatoRepository.Instancia.EstadoMensaje;
        }

        private void BtnLimpiar_Clicked1(object sender, EventArgs e)
        {
            txtInfo.Text = "";
            txtLevel.Text = "";
        }

        private void BtnLeer_Clicked(object sender, EventArgs e)
        {
            var datos = DatoRepository.Instancia.GetAllData();
            userList.ItemsSource = datos;
            lblMensaje.Text = DatoRepository.Instancia.EstadoMensaje;
        }




    }
}
