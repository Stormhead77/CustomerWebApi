using CustomerDatalayer.Entities;
using CustomerDatalayer.Interfaces;
using System.Data.Entity;

namespace CustomerDatalayer.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository()
        {
            _context = new CustomerDbContext();
        }

        public Customer Create(Customer entity)
        {
            var createdEntity =
                _context
                .Customer
                .Add(entity);

            _context.SaveChanges();

            return createdEntity;
        }

        public Customer Read(int id)
        {
            return _context
                .Customer
                .FirstOrDefault(x => x.CustomerID == id);
        }

        public int Update(Customer entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            _context.Customer.Remove(Read(id));

            return _context.SaveChanges();
        }

        public int DeleteAll()
        {
            _context.Database.ExecuteSqlCommand("DELETE FROM dbo.CustomerNotes");
            _context.Database.ExecuteSqlCommand("DELETE FROM dbo.Addresses");
            return _context.Database.ExecuteSqlCommand("DELETE FROM dbo.Customers");
        }

        public List<Customer> ReadAll()
        {
            return _context.Customer.ToList();
        }
    }
}
