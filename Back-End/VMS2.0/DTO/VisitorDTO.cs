using System.ComponentModel.DataAnnotations;

namespace VMS2._0.DTO
{
    public class VisitorDTO
    {
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
    }
}
