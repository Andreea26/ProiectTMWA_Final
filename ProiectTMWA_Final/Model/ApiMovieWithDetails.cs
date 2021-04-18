using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectTMWA_Final.Model

{
    public class ApiMovieWithDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public List<string> Genres { get; set; }
        public string ImageThumbnailPath { get; set; }
    }

}
