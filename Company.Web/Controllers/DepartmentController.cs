using Company.Data.Models;
using Company.Repository.Interface;
using Company.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var dept = _departmentService.GetAll();
            return View(dept);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("DepartmentError", "ValidationError");
            }
            catch (Exception ex) {
                ModelState.AddModelError("DepartmentError", ex.Message);
            }
            return View(department);


        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = _departmentService.GetById(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Update(int id, Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }
            
            _departmentService.Update(department);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var dept= _departmentService.GetById(id);   
            if(dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = _departmentService.GetById(id);
            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            _departmentService.Delete(department);
            return RedirectToAction(nameof(Index));
        }
    }
}
