//using NHibernate.Classic;
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
    public partial class NewMovie : ContentPage
    {
        public NewMovie()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string name = entryName.Text ?? string.Empty;
            StatusType status = MovieHelper.GetStatusEnumItem(statusPicker.SelectedItem.ToString());

            var service = DependencyService.Get<Services.IMoviesService>();

            ResponseStatus reponse = service.AddMovieToMyList(name, status);

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