using System;
using System.Collections.Generic;
using System.Text;
using ProiectTMWA_Final.Model;

namespace ProiectTMWA_Final.Helpers
{
    public class MovieHelper
    {
        const char SPACE = ' ';
        public static StatusType GetStatusEnumItem(string status)
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

        public static string TranslateStatus (StatusType status)
        {
            switch (status)
            {
                case StatusType.NOT_STARTED:
                    return "Not started";
                case StatusType.IN_PROGRESS:
                    return "In progress";
                case  StatusType.WATCHED:
                    return "Watched";
                default:
                    return "";
            }
        }

        public static string GetId(string idAndName)
        {
            return idAndName.Substring(0, idAndName.IndexOf(SPACE));
        }

        public static string GetName(string idAndName)
        {
            return idAndName.Substring(idAndName.IndexOf(SPACE));
        }
    }

}
