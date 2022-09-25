using System.ComponentModel.DataAnnotations;

namespace CustomerDatalayer.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public decimal? TotalPurchasesAmount { get; set; } = 0;
    }
}