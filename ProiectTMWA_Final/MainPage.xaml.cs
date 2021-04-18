using ProiectTMWA_Final.Helpers;
using ProiectTMWA_Final.Model;
using ProiectTMWA_Final.Services;
using ProiectTMWA_Final.Views;
using SQLite;
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

        private void Remove(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            StackLayout listViewItem = (StackLayout)button.Parent;
            Label label = (Label)listViewItem.Children[0];

            String movieId = MovieHelper.GetId(label.Text);

            var service = DependencyService.Get<Services.IMoviesService>();
            ResponseStatus reponse = service.RemoveMovie(int.Parse(movieId));

            if (ResponseStatus.OK.Equals(reponse))
            {
                DisplayAlert("Success", "Movie removed!", "Ok");
            }
            else
            {
                DisplayAlert("Failure", "Movie not removed!", "Ok");
            }

        }

        private void UpdateMovieProgress(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            StackLayout listViewItem = (StackLayout)button.Parent;
            Label label = (Label)listViewItem.Children[0];

            String movieId = MovieHelper.GetId(label.Text);

            var service = DependencyService.Get<Services.IMoviesService>();
            ResponseStatus reponse = service.UpdateProgress(int.Parse(movieId), "Watched");

            if (ResponseStatus.OK.Equals(reponse))
            {
                DisplayAlert("Success", "Status updated!", "Ok");
            }
            else
            {
                DisplayAlert("Failure", "Status not updated!", "Ok");
            }

        }

    }
}
