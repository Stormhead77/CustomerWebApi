using System.Data.Entity;

namespace CustomerDatalayer.Repositories
{
    public class BaseRepository<TEntity> : DbContext where TEntity : class
    {
        private IDbSet<TEntity> Table { get; }

        public BaseRepository()
            : base("Server=localhost;Database=CustomerLib_Tolstykh;Trusted_Connection=True")
        { }

        public TEntity Create(TEntity entity)
        {
            var createdEntity = Table.Add(entity);

            SaveChanges();

            return createdEntity;
        }

        //public TEntity Read(int id)
        //{
        //    return Table.FirstOrDefault(x => x.Id == addressId);
        //}

        public int Update(TEntity entity)
        {
            Entry(entity).State = EntityState.Modified;

            return SaveChanges();

        }

        public int Delete(TEntity entity)
        {
            Table.Remove(entity);

            return SaveChanges();
        }

        public int DeleteAll()
        {
            var qwe = new CustomerDbContext();

            foreach (var entity in qwe.Addresses)
            {
                qwe.Addresses.Remove(entity);
            }

            return SaveChanges();
        }

        public List<TEntity> ReadAll()
        {
            return Table.ToList();
        }

        public List<TEntity> GetPage(int pageSize, int pageNumber)
        {
            return Table
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList();
        }

        public int GetCount()
        {
            return Table.Count();
        }
    }
}
