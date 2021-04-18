//using NHibernate.Classic;
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
            ApiMovie movie = new ApiMovie
            {
                Name = entryName.Text == null ? string.Empty : entryName.Text,
                Status = GetStatusEnumItem(statusPicker.SelectedItem.ToString())
            };
            using(SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<ApiMovie>();
                var nbOfRows = conn.Insert(movie);
                if (nbOfRows > 0)
                {
                    DisplayAlert("Success", "Movie added!", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Movie not added!", "Ok");
                }
            }

        }

        private StatusType GetStatusEnumItem(string status)
        {
            switch (status)
            {
                case "Not started":
                    return StatusType.NOT_STARTED;
                case "In progress":
                    return StatusType.IN_PROGRESS;
                case "Watched":
                    return StatusType.WATCHED;
                default:
                    return StatusType.NOT_STARTED;
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