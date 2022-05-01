using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        public IList<Operacion> History { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            // Eventos del tabbed 
            tbVer.Clicked += TbVer_Clicked;
            tbGuardar.Clicked += TbGuardar_Clicked;

            // Eventos de las operaciones
            bntSuma.Clicked += BntSuma_Clicked;
            bntResta.Clicked += BntResta_Clicked;
            bntDiv.Clicked += BntDiv_Clicked;
            bntMulti.Clicked += BntMulti_Clicked;
            btnLimpiar.Clicked += BtnLimpiar_Clicked;

            // Lista que recupera los datos del archivo
            History = new List<Operacion>();

            // Borramos el historial al entrar al programa (Reto 3)
            //Borrar las siguientes líneas si quieres que se guarde al salir del app
            string nombreArchivo = "prueba.txt";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string rutaCompleta = Path.Combine(ruta, nombreArchivo);

            using (var escritor = File.CreateText(rutaCompleta))
            {
                escritor.WriteLine("");
            }
            // Hasta aquí
            
            BindingContext = this;

        }
        private void BtnLimpiar_Clicked(object sender, EventArgs e)
        {
            lblresult.Text = "0";
            num1.Text = "";
            num2.Text = "";
        }

        // Guarda el resultado de la última operación en un archivo
        private void TbGuardar_Clicked(object sender, EventArgs e)
        {
            string nombreArchivo = "prueba.txt";
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string rutaCompleta = Path.Combine(ruta, nombreArchivo);

            using (var escritor = File.AppendText(rutaCompleta))
            {

                escritor.WriteLine(lblresult.Text);
            }
        }
        // Llama a otro activity donde se nos muestra el historial
        private void TbVer_Clicked(object sender, EventArgs e)
        {
            History.Clear();
            String nombreArchivo = "prueba.txt";
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            String rutaCompleta = Path.Combine(ruta, nombreArchivo);
            if (File.Exists(rutaCompleta))
            {
                using (var lector = new StreamReader(rutaCompleta, true))
                {
                    string TextoLeido;
                    while ((TextoLeido = lector.ReadLine()) != null)
                    {
                        // Por cada línea del documento, guardamos un objeto Operacion
                        // con un atributo resultado en la lista History
                        History.Add(new Operacion(TextoLeido));
                    }
                }
            }
            // Llamamos el otro activity y le pasamos la lista con el historial
            _ = ((NavigationPage)this.Parent).PushAsync(new Page2(History));


        }
        private void BntSuma_Clicked(object sender, EventArgs e)
        {

            if (!IsEmpty())
            {
                int n1 = int.Parse(num1.Text);
                int n2 = int.Parse(num2.Text);
                if (n1 >= 1 & n2 >= 1)
                {
                    string resultado = (n1 + n2).ToString();
                    lblresult.Text = resultado;
                }
            }

        }

        private void BntResta_Clicked(object sender, EventArgs e)
        {

            if (!IsEmpty())
            {
                int n1 = int.Parse(num1.Text);
                int n2 = int.Parse(num2.Text);
                if (n1 >= 1 & n2 >= 1)
                {
                    if (n2 > n1)
                    {
                        string mensaje = "No se puede restar un número mayor a uno menor";
                        _ = AvisoAsync(mensaje);
                    }
                    else
                    {
                        string resultado = (n1 - n2).ToString();
                        lblresult.Text = resultado;
                    }


                }
            }

        }

        private void BntMulti_Clicked(object sender, EventArgs e)
        {
            if (!IsEmpty())
            {
                int n1 = int.Parse(num1.Text);
                int n2 = int.Parse(num2.Text);
                if (n1 >= 1 & n2 >= 1)
                {
                    string resultado = (n1 * n2).ToString();
                    lblresult.Text = resultado;
                }

            }
        }

        private void BntDiv_Clicked(object sender, EventArgs e)
        {

            if (!IsEmpty())
            {
                int n1 = int.Parse(num1.Text);
                int n2 = int.Parse(num2.Text);
                if (n1 >= 1 & n2 >= 1)
                {
                    if (n2 > n1)
                    {
                        string mensaje = "No se puede dividir un número menor entre uno mayor";
                        _ = AvisoAsync(mensaje);
                    }
                    else if (n1 == 0 | n2 == 0)
                    {
                        string mensaje = "No se puede realizar division por 0";
                        _ = AvisoAsync(mensaje);
                    }
                    else
                    {
                        string resultado = (n1 / n2).ToString();
                        lblresult.Text = resultado;
                    }

                }

            }
        }
        // Funcion para verificar si los 2 entrys tienen valores
        private bool IsEmpty()
        {
            try
            {
                int n1 = int.Parse(num1.Text);
                int n2 = int.Parse(num2.Text);
                return false;
            }
            catch (Exception)
            {
                string mensaje = "Debe ingresar números en los 2 entrys";
                _ = AvisoAsync(mensaje);
                return true;
            }

        }

        // Despliega un mensaje emergente
        public async Task AvisoAsync(string mensaje)
        {
            await DisplayAlert("Aviso", mensaje, "OK");
        }

    }
}
