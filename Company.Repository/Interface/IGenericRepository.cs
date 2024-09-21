using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        List<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
