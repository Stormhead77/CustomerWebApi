using CustomerDatalayer.Entities;
using CustomerDatalayer.Interfaces;
using System.Data.Entity;

namespace CustomerDatalayer.Repositories
{
    public class CustomerNoteRepository : IRepository<CustomerNote>
    {
        private readonly CustomerDbContext _context;

        public CustomerNoteRepository()
        {
            _context = new CustomerDbContext();
        }

        public CustomerNote Create(CustomerNote entity)
        {
            var createdEntity =
                _context
                    .CustomerNotes
                    .Add(entity);

            _context.SaveChanges();

            return createdEntity;
        }

        public CustomerNote Read(int id)
        {
            return _context
                .CustomerNotes
                .FirstOrDefault(x => x.CustomerID == id);
        }

        public int Update(CustomerNote entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            _context.CustomerNotes.Remove(Read(id));

            return _context.SaveChanges();
        }

        public int DeleteAll()
        {
            return _context.Database.ExecuteSqlCommand("DELETE FROM dbo.CustomerNotes");
        }

        public List<CustomerNote> ReadAll()
        {
            return _context.CustomerNotes.ToList();
        }
    }
}
