using Company.Data.Models;
using Company.Repository.Interface;
using Company.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Sevices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void Add(Department department)
        {
            _departmentRepository.Add(department);  
        }

        public void Delete(Department department)
        {
            _departmentRepository.Delete(department);
        }

        public IEnumerable<Department> GetAll()
        {
            return _departmentRepository.GetAll().Where(x=>x.IsDeleted !=true); 
        }

        public Department GetById(int? id)
        {
            if (id is null)
            {
                return null; 
            }
            var dept= _departmentRepository.GetById(id);
            if (dept is null) {

                return null;
            }
            else
            {
                return dept;    
            }
        }

        public void Update(Department department)
        {
            var dept = _departmentRepository.GetById(department.Id);
            if (dept.Name != department.Name)
            {
                if (GetAll().Any(x=>x.Name == department.Name)) {
                    throw new Exception("Duplicate DepartmentsName");
                }
                
            }
            dept.Name = department.Name;   
            dept.Code= department.Code;

            _departmentRepository.Update(dept);
        }
    }
}
