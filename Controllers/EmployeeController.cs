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
        public EmployeeController()
        {
            employeeRepository = new EmployeeRepository();
        }
        // GET: Employee
        public ActionResult Index()
        {
            var employeeModels = employeeRepository.GetEmployees();
            return View(employeeModels);
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


        public ActionResult Update(int Id)
        {
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