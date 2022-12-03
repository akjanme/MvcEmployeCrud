using MvcEmployeCrud.Models;
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
        // GET: Employee
        public ActionResult Index()
        {
            List<EmployeeModel> employeeModels = new List<EmployeeModel>();
            SqlConnection con = new SqlConnection(Constr);
            SqlCommand cmd = new SqlCommand("select * from employee", con);
            con.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet != null)
            {
                foreach (DataRow employee in dataSet.Tables[0].Rows)
                {
                    EmployeeModel employeeModel = new EmployeeModel();
                    employeeModel.ID = Convert.ToInt32(employee["ID"]);
                    employeeModel.Name = Convert.ToString(employee["EmpName"]);
                    employeeModel.FatherName = Convert.ToString(employee["FatherName"]);
                    employeeModel.Mobile = Convert.ToString(employee["Mobile"]);
                    employeeModels.Add(employeeModel);
                }
            }
            con.Close();
            return View(employeeModels);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            SqlConnection con = new SqlConnection(Constr);
            SqlCommand cmd = new SqlCommand("insert into employee(empname,fathername,mobile) values (@name,@fathername,@mobile)", con);
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@fathername", employee.FatherName);
            cmd.Parameters.AddWithValue("@mobile", employee.Mobile); 
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return View(employee);
        }


        public ActionResult Update(int Id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            SqlConnection con = new SqlConnection(Constr);
            SqlCommand cmd = new SqlCommand("select * from employee where id=@id", con);
            cmd.Parameters.AddWithValue("@id", Id);
            con.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet != null)
            {  
                   
                    employeeModel.ID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ID"]);
                    employeeModel.Name = Convert.ToString(dataSet.Tables[0].Rows[0]["EmpName"]);
                    employeeModel.FatherName = Convert.ToString(dataSet.Tables[0].Rows[0]["FatherName"]);
                    employeeModel.Mobile = Convert.ToString(dataSet.Tables[0].Rows[0]["Mobile"]); 
            }
            con.Close();
            return View(employeeModel);
        }
        [HttpPost]
        public ActionResult Update(int id, EmployeeModel employee)
        {
            SqlConnection con = new SqlConnection(Constr);
            SqlCommand cmd = new SqlCommand("update employee set empname=@name,fathername=@fathername,mobile=@mobile where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@fathername", employee.FatherName);
            cmd.Parameters.AddWithValue("@mobile", employee.Mobile);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return View(employee);
        }
    }
}