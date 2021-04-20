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
      
            var movies = DependencyService.Get<Services.IMoviesService>().GetAllMovies();
            moviesListView.ItemsSource = movies;


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

        private async void Remove(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            StackLayout listViewItem = (StackLayout)button.Parent;
            Label label = (Label)listViewItem.Children[0];

            String movieId = MovieHelper.GetId(label.Text);

            var service = DependencyService.Get<Services.IMoviesService>();
            ResponseStatus reponse = service.RemoveMovie(int.Parse(movieId));


            if (ResponseStatus.OK.Equals(reponse))
            {
                await DisplayAlert("Success", "Movie removed!", "Ok");
            }
            else
            {
                await DisplayAlert("Failure", "Movie not removed!", "Ok");
            }

            OnAppearing();

        }

        private async void UpdateMovieProgressNotStarted(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            StackLayout listViewItem = (StackLayout)button.Parent;
            Label label = (Label)listViewItem.Children[0];

            String movieId = MovieHelper.GetId(label.Text);

            var service = DependencyService.Get<Services.IMoviesService>();
            ResponseStatus reponse = service.UpdateProgress(int.Parse(movieId), StatusType.NOT_STARTED);

            if (ResponseStatus.OK.Equals(reponse))
            {
                await DisplayAlert("Success", "Status updated!", "Ok");
            }
            else
            {
                await DisplayAlert("Failure", "Status not updated!", "Ok");
            }
            OnAppearing();
        }

        private async void UpdateMovieProgressWatched(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            StackLayout listViewItem = (StackLayout)button.Parent;
            Label label = (Label)listViewItem.Children[0];

            String movieId = MovieHelper.GetId(label.Text);

            var service = DependencyService.Get<Services.IMoviesService>();
            ResponseStatus reponse = service.UpdateProgress(int.Parse(movieId), StatusType.WATCHED);

            if (ResponseStatus.OK.Equals(reponse))
            {
                await DisplayAlert("Success", "Status updated!", "Ok");
            }
            else
            {
                await DisplayAlert("Failure", "Status not updated!", "Ok");
            }
            OnAppearing();
        }

        private async void UpdateMovieProgressInProgress(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            StackLayout listViewItem = (StackLayout)button.Parent;
            Label label = (Label)listViewItem.Children[0];

            String movieId = MovieHelper.GetId(label.Text);

            var service = DependencyService.Get<Services.IMoviesService>();
            ResponseStatus reponse = service.UpdateProgress(int.Parse(movieId), StatusType.IN_PROGRESS);

            if (ResponseStatus.OK.Equals(reponse))
            {
                await DisplayAlert("Success", "Status updated!", "Ok");
            }
            else
            {
                await DisplayAlert("Failure", "Status not updated!", "Ok");
            }
            OnAppearing();
        }

        private void OnItemSelectedFilter(object sender, EventArgs e)
        {
            var moviesFiltered = new List<ApiMovie>();
            string selectedItem = filterByStatusPicker.SelectedItem.ToString();

            var service = DependencyService.Get<Services.IMoviesService>();
            var movies = service.GetAllMovies();

            if (!selectedItem.Equals("ALL"))
            {
                StatusType status = MovieHelper.GetStatusEnumItem(selectedItem);

                foreach (ApiMovie movie in movies)
                {
                    if (movie.Status.Equals(status))
                    {
                        moviesFiltered.Add(movie);
                    }
                }
                moviesListView.ItemsSource = moviesFiltered;
            }
            else
            {
                moviesListView.ItemsSource = movies;
            }
        }
    }
}
