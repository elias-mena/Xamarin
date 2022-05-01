using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;

namespace ActionBar
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Tb1.Clicked += Tb1_Clicked;
            Tb2.Clicked += Tb2_Clicked;
            Tb3.Clicked += Tb3_Clicked;
            Tb4.Clicked += Tb4_Clicked;

            BtnSave.Clicked += BtnSave_Clicked;
            BtnRestore.Clicked += BtnRestore_Clicked;
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            String nombreArchivo = "prueba.txt";
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            String rutaCompleta = Path.Combine(ruta, nombreArchivo);
            using (var escritor = File.CreateText(rutaCompleta))
            { 
                escritor.Write(txtGuardar.Text); 
            }
        }

        private void BtnRestore_Clicked(object sender, EventArgs e)
        {
            String nombreArchivo = "prueba.txt";
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            String rutaCompleta = Path.Combine(ruta, nombreArchivo);
            if (File.Exists(rutaCompleta))
            {
                using (var lector = new StreamReader(rutaCompleta, true))
                {
                    String TextoLeido;
                    while ((TextoLeido = lector.ReadLine()) != null)
                    {
                        txtRestored.Text = TextoLeido;
                    }
                }
            }
        }

        private void Tb4_Clicked(object sender, EventArgs e)
        {
            lbl01.Text = "Logout seleccionado";
        }

        private void Tb3_Clicked(object sender, EventArgs e)
        {
            lbl01.Text = "About seleccionado";
        }

        private void Tb2_Clicked(object sender, EventArgs e)
        {
            lbl01.Text = "Icono about seleccioando";
        }

        private void Tb1_Clicked(object sender, EventArgs e)
        {
            lbl01.Text = "Home seleccionado";
        }
    }
}
