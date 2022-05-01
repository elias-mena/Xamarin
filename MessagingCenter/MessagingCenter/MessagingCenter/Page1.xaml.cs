using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessagingCenter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Hola");
        }
    }
}