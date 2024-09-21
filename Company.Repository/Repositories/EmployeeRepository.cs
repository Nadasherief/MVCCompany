using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {
        private readonly CompanyDBContext _context;

        public EmployeeRepository(CompanyDBContext companyDBContext) : base(companyDBContext) 
        {
            _context = companyDBContext;
        }

        public Employee GetByName(string name)
        =>_context.Set<Employee>().Find(name);
    }
}
