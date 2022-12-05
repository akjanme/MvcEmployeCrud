using MvcEmployeCrud.Models;
using MvcEmployeCrud.Repository;
using System.Web.Mvc;

namespace MvcEmployeCrud.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentRepository _departmentRepository;
        public DepartmentController()
        {
            _departmentRepository = new DepartmentRepository();
        }
        // GET: Department
        public ActionResult Index()
        {
            var departments = _departmentRepository.GetDepartments();
            return View(departments);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DepartmentModel departmentModel)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.AddDepartment(departmentModel);
            }
            ViewBag.Message = "Saved Successfully";
            return View(departmentModel);
        }
    }
}