using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace CustomerDatalayer.Entities
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public int CustomerID { get; set; }
        [Required]
        [MaxLength(100)]
        public string AddressLine { get; set; }
        [MaxLength(100)]
        public string AddressLine2 { get; set; }
        public string AddressType { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(6)]
        public string PostalCode { get; set; }
        [Required]
        [MaxLength(20)]
        public string State { get; set; }
        public string Country { get; set; }
    }
}
