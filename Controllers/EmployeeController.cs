using MvcEmployeCrud.Models;
using MvcEmployeCrud.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MvcEmployeCrud.Controllers
{ 
    public class EmployeeController : Controller
    {
        string Constr = WebConfigurationManager.ConnectionStrings["empConnectionString"].ConnectionString;
        EmployeeRepository employeeRepository;
        DepartmentRepository _departmentRepository;
        public EmployeeController()
        {
            employeeRepository = new EmployeeRepository();
            _departmentRepository = new DepartmentRepository();
        }
        // GET: Employee 
        public ActionResult Index()
        { 

            EmployeeDepartmentModel employeeDepartmentModel = new EmployeeDepartmentModel();
            employeeDepartmentModel.departmentModels= _departmentRepository.GetDepartments();
            employeeDepartmentModel.employeeModels= employeeRepository.GetEmployees();

            ViewData["EmployeeList"]= employeeRepository.GetEmployees();

            ViewBag.EmployeeDepartment = employeeRepository.GetEmployees(); 

            TempData["EmployeeList"] = employeeRepository.GetEmployees();
            
            TempData.Keep("EmployeeList");

            return View(employeeDepartmentModel);
        }

        public ActionResult Create()
        {
            return View(new EmployeeModel());
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Detail(int Id)
        {
            TempData.Keep("EmployeeList");
            var employeeModel = employeeRepository.GetEmployeeById(Id);
            return Json(employeeModel,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(int Id)
        {
            TempData.Keep("EmployeeList");
            var employeeModel = employeeRepository.GetEmployeeById(Id);
            return View(employeeModel);
        }
        [HttpPost]
        public ActionResult Update(int id, EmployeeModel employee)
        {
            employeeRepository.Update(employee);
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            employeeRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}