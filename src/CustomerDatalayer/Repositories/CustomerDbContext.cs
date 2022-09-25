using CustomerDatalayer.Entities;
using System.Data.Entity;

namespace CustomerDatalayer.Repositories
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext()
            : base("Server=localhost;Database=CustomerLib_Tolstykh;Trusted_Connection=True")
        { }

        public IDbSet<Customer> Customer { get; set; }
        public IDbSet<Address> Addresses { get; set; }
        public IDbSet<CustomerNote> CustomerNotes { get; set; }
    }
}
