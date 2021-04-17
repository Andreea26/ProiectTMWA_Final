using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectTMWA_Final.Model
{
    public class Movie
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public double Score { get; set; }

        public string Text => $"{Name}";
        public string TextDetail => $"Year: {Year}, Genre: {Genre}, Duration: {Duration}, Score: {Score}";
    }
}
