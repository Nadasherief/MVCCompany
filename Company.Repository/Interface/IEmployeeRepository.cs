using Company.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        List<Employee> GetAll();
        void Add (Employee employee); 
        void Delete (Employee employee);
        void Update (Employee employee);
    }
}
