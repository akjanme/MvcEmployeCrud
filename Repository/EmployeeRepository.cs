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
    public class EmployeeRepository
    {
        string Constr = WebConfigurationManager.ConnectionStrings["empConnectionString"].ConnectionString;
        // GET: Employee
        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> employeeModels = new List<EmployeeModel>();
            SqlConnection con = new SqlConnection(Constr);
            SqlCommand cmd = new SqlCommand("sp_GetEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
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
            return employeeModels;
        }

        public bool AddEmployee(EmployeeModel employee)
        {
            SqlConnection con = new SqlConnection(Constr);
            SqlCommand cmd = new SqlCommand("sp_InsertEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@fathername", employee.FatherName);
            cmd.Parameters.AddWithValue("@mobile", employee.Mobile);
            con.Open();
            int result= cmd.ExecuteNonQuery(); 
            con.Close();
            if (result == 0)
                return true;
            else
                return false;
        }


        public EmployeeModel GetEmployeeById(int Id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            SqlConnection con = new SqlConnection(Constr);
            SqlCommand cmd = new SqlCommand("sp_GetEmployeeByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
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
            return employeeModel;
        } 
        public bool Update(EmployeeModel employee)
        {
            SqlConnection con = new SqlConnection(Constr);
            SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", employee.ID);
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@fathername", employee.FatherName);
            cmd.Parameters.AddWithValue("@mobile", employee.Mobile);
            con.Open(); 
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 0)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            SqlConnection con = new SqlConnection(Constr);
            SqlCommand cmd = new SqlCommand("sp_DeleteEmployeeByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 0)
                return true;
            else
                return false; 
        }
    }
}