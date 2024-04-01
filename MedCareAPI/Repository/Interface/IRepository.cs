namespace MedCareAPI.Repository.Interface
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> Get();
    }
}
