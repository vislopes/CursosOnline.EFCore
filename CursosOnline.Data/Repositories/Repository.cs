using CursosOnline.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CursosOnline.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public T? GetById(int id)
        => _context.Set<T>().Find(id);

    public List<T> GetAll()
        => _context.Set<T>().ToList();

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
}

