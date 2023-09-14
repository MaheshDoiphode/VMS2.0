using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VMS2._0.Models
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        [ForeignKey("VisitID")]
        public int VisitID { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string NotificationType { get; set; }

        [Required]
        public DateTime NotificationGenerated { get; set; }

        [Required]
        public string NotificationStatus { get; set; }

        public Visit Visit { get; set; }
    }

}
