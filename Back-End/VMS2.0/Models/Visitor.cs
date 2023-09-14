using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VMS2._0.Models
{
    public class Visitor
    {
        [Key]
        public int VisitorID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        [Required]
        [EmailAddress]
        public string VisitorEmail { get; set; }

        [Required]
        public string VisitorNumber { get; set; }

        public string VisitorAddress { get; set; }

        [Required]
        public string IdentityType { get; set; }

        [Required]
        public string IdentityNumber { get; set; }

        public byte[] Image { get; set; }

        public ICollection<Visit> Visits { get; set; }
    }
}
