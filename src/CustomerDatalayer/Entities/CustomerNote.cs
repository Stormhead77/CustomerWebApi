using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace CustomerDatalayer.Entities
{
    public class CustomerNote
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public string NoteText { get; set; }
    }
}
