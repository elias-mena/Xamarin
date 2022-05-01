using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tarea4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            bntSuma.Clicked += BntSuma_Clicked;
            bntResta.Clicked += BntResta_Clicked;
            bntDiv.Clicked += BntDiv_Clicked;
            bntMulti.Clicked += BntMulti_Clicked;
        }

        private void BntSuma_Clicked(object sender, EventArgs e)
        {
            int n1 = int.Parse(num1.Text);
            int n2 = int.Parse(num2.Text);
            label.Text = "";
            if (n1 > 1 & n2 > 1)
            {

                string resultado = (n1 + n2).ToString();
                label.Text = "La suma de los números es: " + resultado;


            }
            else
            {
                label.Text = "Error";
            }
        }

        private void BntResta_Clicked(object sender, EventArgs e)
        {
            int n1 = int.Parse(num1.Text);
            int n2 = int.Parse(num2.Text);
            label.Text = "";
            if (n1 > 1 & n2 > 1)
            {
                if (n2 > n1)
                {
                    label.Text = "No se puede restar un número mayor a uno menor";
                }
                else
                {
                    string resultado = (n1 / n2).ToString();
                    label.Text = "La resta de los números es: " + resultado;
                }

            }
            else
            {
                label.Text = "Error";
            }
        }

        private void BntMulti_Clicked(object sender, EventArgs e)
        {
            int n1 = int.Parse(num1.Text);
            int n2 = int.Parse(num2.Text);
            label.Text = "";
            if (n1 > 1 & n2 > 1)
            {

                string resultado = (n1 * n2).ToString();
                label.Text = "La multiplicación de los números es: " + resultado;


            }
            else
            {
                label.Text = "Error";
            }
        }

        private void BntDiv_Clicked(object sender, EventArgs e)
        {
            int n1 = int.Parse(num1.Text);
            int n2 = int.Parse(num2.Text);
            label.Text = "";
            if (n1 > 1 & n2 > 1)
            {
                if (n2 > n1)
                {
                    label.Text = "No se puede dividir un número menor entre uno mayor";
                }
                else
                {
                    string resultado = (n1 / n2).ToString();
                    label.Text = "La división de los números es: " + resultado;
                }

            }
            else
            {
                label.Text = "Error";
            }
        }
    }
}
