public interface IRepository<T> // defines generic crud operations
{
    void Add(T item);
    List<T> GetAll();
    T? GetById(int id);
    void Update(T item);
    void Delete(int id);

}
