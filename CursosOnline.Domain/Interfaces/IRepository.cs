using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursosOnline.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T? GetById(int id);
        List<T> GetAll();
        void Update(T entity);
        void Delete(T entity);
    }
}
