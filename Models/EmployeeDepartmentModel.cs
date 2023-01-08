using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEmployeCrud.Models
{
    public class EmployeeDepartmentModel
    {
        public List<EmployeeModel> employeeModels { get; set; }
        public List<DepartmentModel> departmentModels { get; set; }
    }
}