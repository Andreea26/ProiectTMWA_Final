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
            Movie movie = new Movie()
            {
                Name = entryName.Text == null ? string.Empty : entryName.Text,
                Year = int.Parse(entryYear.Text),
                Genre = entryGenre.Text,
                Duration = int.Parse(entryDuration.Text),
                Score = double.Parse(entryScore.Text)
            };
            using(SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Movie>();
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
    }
}