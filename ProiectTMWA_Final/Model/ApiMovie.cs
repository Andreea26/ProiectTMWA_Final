using System;
using System.Collections.Generic;
using System.Text;
using ProiectTMWA_Final.Helpers;
using SQLite;

namespace ProiectTMWA_Final.Model
{
    public class ApiMovie
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageThumbnailPath { get; set; }
        public StatusType Status { get; set; }

        public string NameDisplayed => $"{Name}";

        public bool DisplayNotStartedButton
        {
            get
            {
                if (Status == StatusType.WATCHED)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                
            }
        }
        public bool DisplayInProgressButton
        {
            get
            {
                if (Status == StatusType.NOT_STARTED || Status == StatusType.WATCHED)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {

            }
        }
        public bool DisplayWatchedButton
        {
            get
            {
                if (Status == StatusType.IN_PROGRESS)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {

            }
        }

    
        public string StatusDisplayed => MovieHelper.TranslateStatus(Status);

        public string ImageUrl => $"{ImageThumbnailPath}";

        public override string ToString()
        {
            return Id + " " + Name;
        }

    }
}
