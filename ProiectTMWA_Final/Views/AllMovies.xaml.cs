using MvvmHelpers;
using ProiectTMWA_Final.Helpers;
using ProiectTMWA_Final.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectTMWA_Final.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllMovies : ContentPage
    {
        public AllMovies()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var service = DependencyService.Get<Services.IMoviesService>();
            var results = await service.ShowAllMovies();
            listView.ItemsSource = results;
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

        async void ShowDetails(object sender, EventArgs e)
        {
           
            Button button = (Button)sender;
            StackLayout listViewItem = (StackLayout)button.Parent;
            Label label = (Label)listViewItem.Children[0];
            String data = label.Text;

            string id = MovieHelper.GetId(data);
            var service = DependencyService.Get<Services.IMoviesService>();
            var results = await service.ShowMovieDetails(Int32.Parse(id));

            String genresList = "";
            foreach (string genre in results.Genres)
            {
                genresList = genresList + genre + ", ";  
            }

            bool answer = await DisplayAlert(results.Name + " - " + Math.Round(results.Rating, 2), "Genres: " + genresList + Environment.NewLine + Environment.NewLine + results.Description, "Add to My List", "Cancel");
            Console.WriteLine(answer);


        }

        private void AddToMyList(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            StackLayout listViewItem = (StackLayout)button.Parent;
            Label label = (Label)listViewItem.Children[0];

            String movieId = MovieHelper.GetId(label.Text);
            String movieName = MovieHelper.GetName(label.Text);

            var service = DependencyService.Get<Services.IMoviesService>();
            ResponseStatus reponse = service.AddMovieToMyList(movieName, Model.StatusType.NOT_STARTED, int.Parse(movieId));

            if (ResponseStatus.OK.Equals(reponse))
            {
                DisplayAlert("Success", "Movie added!", "Ok");
            }
            else if (ResponseStatus.NOT_OK.Equals(reponse))
            {
                DisplayAlert("Failure", "Movie not added!", "Ok");
            }
            else
            {
                DisplayAlert("Failure", "Movie is already in your list!", "Ok");
            }
        }
    }
}