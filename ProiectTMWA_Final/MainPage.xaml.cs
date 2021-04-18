using ProiectTMWA_Final.Model;
using ProiectTMWA_Final.Services;
using ProiectTMWA_Final.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProiectTMWA_Final
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<ApiMovie>();
                var movies = conn.Table<ApiMovie>().ToList();
                moviesListView.ItemsSource = movies;
            }

        }
        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewMovie());
        }

        private void AddMovie_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewMovie());
        }

        private void AllMovies_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AllMovies());
        }

        private void MyMovies_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

    }
}
