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
    }
}