﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Catalogo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            MainPage = new Productos();
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
