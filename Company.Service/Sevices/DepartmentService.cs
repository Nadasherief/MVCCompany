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
        private readonly IUnitofWork _unitofWork;

        public DepartmentService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public void Add(Department department)
        {
            var mappedDepartment = new Department
            {
                Code = department.Code,
                Name = department.Name,
                CreatedAt = DateTime.Now
            };
            _unitofWork.departmentRepository.Add(mappedDepartment);
            _unitofWork.Complete();
        }

        public void Delete(Department department)
        {
            _unitofWork.departmentRepository.Delete(department);
            _unitofWork.Complete();

        }

        public IEnumerable<Department> GetAll()
        {
            return _unitofWork.departmentRepository.GetAll().Where(x=>x.IsDeleted !=true); 
        }

        public Department GetById(int? id)
        {
            if (id is null)
            {
                return null; 
            }
            var dept= _unitofWork.departmentRepository.GetById(id);
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
            var dept = _unitofWork.departmentRepository.GetById(department.Id);
            if (dept.Name != department.Name)
            {
                if (GetAll().Any(x=>x.Name == department.Name)) {
                    throw new Exception("Duplicate DepartmentsName");
                }
                
            }
            dept.Name = department.Name;   
            dept.Code= department.Code;

            _unitofWork.departmentRepository.Update(dept);
            _unitofWork.Complete();

        }
    }
}
