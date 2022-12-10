using MvcEmployeCrud.DAL;
using MvcEmployeCrud.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MvcEmployeCrud.Repository
{
    public class DepartmentRepository
    {
        CompanyDBEntities _companyDBEntities = new CompanyDBEntities();
        // GET: Employee
        public List<DepartmentModel> GetDepartments()
        {
            List<DepartmentModel> departmentModels = new List<DepartmentModel>();
            foreach (var employee in _companyDBEntities.Departments.ToList())
            {
                DepartmentModel departmentModel = new DepartmentModel();
                departmentModel.ID = employee.ID.ToString();
                departmentModel.Name = employee.Name;
                departmentModels.Add(departmentModel);
            }
            return departmentModels;
        }

        public bool AddDepartment(DepartmentModel departmentModel)
        {
            Department department = new Department
            {
                ID = new Guid(departmentModel.ID),
                Name = departmentModel.Name
            };
            _companyDBEntities.Departments.Add(department);
            _companyDBEntities.SaveChanges();
            return true;
        }


        public DepartmentModel GetDepartmentById(string Id)
        {
            var department = _companyDBEntities.Departments.FirstOrDefault(x => x.ID == new Guid(Id));
            DepartmentModel departmentModel = new DepartmentModel
            {
                ID = department.ID.ToString(),
                Name = department.Name
            };
            return departmentModel;
        }
        public bool Update(DepartmentModel departmentModel)
        {
            Department department = new Department
            {
                ID = new Guid(departmentModel.ID),
                Name = departmentModel.Name
            };
            _companyDBEntities.Entry<Department>(department);
            _companyDBEntities.Entry(department).State = System.Data.Entity.EntityState.Modified;
            _companyDBEntities.SaveChanges();
            return true;
        }

        public bool Delete(string id)
        {
            var department = _companyDBEntities.Departments.FirstOrDefault(x => x.ID == new Guid(id)); 
            _companyDBEntities.Departments.Remove(department);
            _companyDBEntities.SaveChanges();
            return true;
        }



        private List<DepartmentModel> GetDepartmentsList()
        {
            List<DepartmentModel> departmentModels = new List<DepartmentModel>();
            foreach (var employee in _companyDBEntities.Departments.ToList())
            {
                DepartmentModel departmentModel = new DepartmentModel();
                departmentModel.ID = employee.ID.ToString();
                departmentModel.Name = employee.Name;
                departmentModels.Add(departmentModel);
            }
            return departmentModels;
        }


        private List<DepartmentModel> GetDepartmentsByName(string name)
        {
            var departmentlist = GetDepartmentsList();
            return departmentlist.Where(x=>x.Name == name).ToList(); 
        }
        private List<string> GetDepartmentsID()
        {
            var departmentlist = GetDepartmentsList();
            return departmentlist.Select(x => x.Name).ToList();
        }
        private List<char> GetDepartmentsselectMany()
        {
            var departmentlist = GetDepartmentsList();
            return departmentlist.SelectMany(x => x.Name).ToList();
        }
        private List<DepartmentModel> GetUniqueRecord()
        {
            var departmentlist = GetDepartmentsList();
            return departmentlist.Distinct().ToList();
        }
    }

}