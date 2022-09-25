namespace CustomerDatalayer.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity Create(TEntity entity);
        TEntity Read(int id);
        int Update(TEntity entity);
        int Delete(int id);
        int DeleteAll();
        List<TEntity> ReadAll();
    }
}
