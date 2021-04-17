﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectTMWA_Final
{
    public partial class App : Application
    {
        public static string DB_PATH = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string db_path)
        {
            InitializeComponent();
            DB_PATH = db_path;
            MainPage = new NavigationPage(new MainPage());
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
