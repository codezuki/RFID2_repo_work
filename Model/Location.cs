using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RFID2.Model
{
    [Table("Server_Location")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal LocationID { get; set; }

        [Required]
        [StringLength(20)]
        public string? LocationName { get; set; }

        public bool? Active { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? LastUpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }

}
