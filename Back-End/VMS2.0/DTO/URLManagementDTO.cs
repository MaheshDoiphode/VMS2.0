using System.ComponentModel.DataAnnotations;

namespace VMS2._0.DTO
{
    public class URLManagementDTO
    {
        public int URLID { get; set; }

        [Required]
        public int VisitID { get; set; }

        [Required]
        public DateTime ExpirationTime { get; set; }

        [Required]
        public DateTime GenerateDate { get; set; }

        [Required]
        public string URLStatus { get; set; }

        [Required]
        public string URLType { get; set; }
    }
}
