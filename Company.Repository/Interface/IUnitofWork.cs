using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Interface
{
    public interface IUnitofWork
    {
        public IDepartmentRepository departmentRepository {  get; set; } 
        public IEmployeeRepository employeeRepository { get; set;}
        int Complete();
    }
}
