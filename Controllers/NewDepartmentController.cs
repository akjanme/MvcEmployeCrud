using MvcEmployeCrud.DAL;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcEmployeCrud.Controllers
{
    public class NewDepartmentController : Controller
    {
        CompanyDBEntities _companyDBEntities;
        public NewDepartmentController()
        {
            _companyDBEntities= new CompanyDBEntities();
        }
        // GET: NewDepartment
        public ActionResult Index()
        {
            var departments = _companyDBEntities.Departments.ToList();
            return View(departments);
        }
        public ActionResult Update(string id)
        {
            var department = _companyDBEntities.Departments.FirstOrDefault(x=>x.ID==new Guid(id));
            return View(department);
        }
        [HttpPost]
        public ActionResult Update(Department department)
        {
            _companyDBEntities.Entry(department).State = System.Data.Entity.EntityState.Modified;
            _companyDBEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View(new Department());
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            department.ID = Guid.NewGuid();
            _companyDBEntities.Departments.Add(department);
            _companyDBEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string Id)
        {
            var department =_companyDBEntities.Departments.FirstOrDefault(x => x.ID == new Guid(Id));
            if (department != null)
            {
                _companyDBEntities.Departments.Remove(department);
                _companyDBEntities.SaveChanges(); 
            }
            return RedirectToAction("Index"); 
        }
    }
}