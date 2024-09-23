using Company.Data.Contexts;
using Company.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly CompanyDBContext _context;

        public UnitOfWork(CompanyDBContext context)
        {
            departmentRepository = new DepartmentRepository(context);
            employeeRepository = new EmployeeRepository(context);
            _context = context;
        }

        public IDepartmentRepository departmentRepository { get; set ; }
        public IEmployeeRepository employeeRepository { get ; set ; }

        public int Complete()
        {
           return _context.SaveChanges();
        }
    }
}
