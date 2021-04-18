using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ProiectTMWA_Final.Model
{
    public class ApiMovie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageThumbnailPath { get; set; }
        public StatusType Status { get; set; }

        public string NameDisplayed => $"{Name}";

        public string StatusDisplayed => $"{Status}";

        public string ImageUrl => $"{ImageThumbnailPath}";

        public string IdToDisplay => $"{Id}";

    }
}
