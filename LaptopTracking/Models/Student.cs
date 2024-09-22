using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LaptopTracking.Models
{
    public class UserLog
    {
        [Display(Name = "User Id")]
        public string UserId { get; set; } = string.Empty;

        [Display(Name = "Name")]
        public string Host { get; set; } = string.Empty;

        [Display(Name = "Date")]
        public string Date { get; set; }

        [Display(Name = "First Login")]
        public DateTime FISTlOGIN { get; set; }

        [Display(Name = "Last LogOff")]
        public DateTime LASTLOGOFF { get; set; }

        [Display(Name = "Total Active Time")]
        public string TotalActiveTime { get; set; }

    }
    public class AppLog
    {
        [Display(Name = "User Id")]
        public string UserId { get; set; } = string.Empty;

        [Display(Name = "Name")]
        public string Host { get; set; } = string.Empty;

        [Display(Name = "Date")]
        public string Date { get; set; }

        [Display(Name = "App")]
        public string App { get; set; }

        [Display(Name = "App Activity")]
        public string AppActivity { get; set; }
    }

}
