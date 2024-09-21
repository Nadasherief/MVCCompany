using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CompanyDBContext _companyDBContext;

        public EmployeeRepository(CompanyDBContext companyDBContext)
        {
            _companyDBContext = companyDBContext;
        }
        public void Add(Employee employee)
        =>_companyDBContext.Employees.Add(employee);      

        public void Delete(Employee employee)
        =>_companyDBContext.Remove(employee);
        public List<Employee> GetAll()
        => _companyDBContext.Employees.ToList();

        public Employee GetById(int id)
        => _companyDBContext.Employees.FirstOrDefault(x => x.Id == id );    
        

        public void Update(Employee employee)
         => _companyDBContext.Employees.Update(employee);

    }
}
