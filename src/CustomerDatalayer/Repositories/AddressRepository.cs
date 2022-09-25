using CustomerDatalayer.Entities;
using CustomerDatalayer.Interfaces;
using System.Data;
using System.Data.Entity;

namespace CustomerDatalayer.Repositories
{
    public class AddressRepository : IRepository<Address>
    {
        private readonly CustomerDbContext _context;

        public AddressRepository()
        {
            _context = new CustomerDbContext();
        }

        public Address Create(Address entity)
        {
            var createdEntity =
                _context
                    .Addresses
                    .Add(entity);

            _context.SaveChanges();

            return createdEntity;
        }

        public Address Read(int id)
        {
            return _context
                .Addresses
                .FirstOrDefault(x => x.AddressID == id);
        }

        public int Update(Address entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            _context.Addresses.Remove(Read(id));

            return _context.SaveChanges();
        }

        public int DeleteAll()
        {
            return _context.Database.ExecuteSqlCommand("DELETE FROM dbo.Addresses");
        }

        public List<Address> GetAddressesByCustomerId(int customerId)
        {
            return _context.Addresses.Where(x => x.CustomerID == customerId).ToList();
        }

        public List<Address> ReadAll()
        {
            return _context.Addresses.ToList();
        }
    }
}
