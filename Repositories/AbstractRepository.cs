using System.Collections.Generic;

public abstract class AbstractRepository<T> : IRepository<T>
{
    protected List<T> items = new List<T>();

    public virtual void Add(T item) => items.Add(item);

    public virtual List<T> GetAll()
    {
        return items;
    }

    public abstract T? GetById(int id);

    public abstract void Update(T item);

    public abstract void Delete(int id);
}