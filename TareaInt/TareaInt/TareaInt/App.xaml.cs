using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TareaInt.Model;
namespace TareaInt
{
    public partial class App : Application
    {
        public App(string filename)
        {
            InitializeComponent();
            DatoRepository.Inicializador(filename);
            MainPage = new MainPage();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
