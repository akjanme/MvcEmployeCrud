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
        string Constr = WebConfigurationManager.ConnectionStrings["empConnectionString"].ConnectionString;
        // GET: Employee
        public List<DepartmentModel> GetDepartments()
        {
            List<DepartmentModel> departmentModels = new List<DepartmentModel>();
            SqlConnection con = new SqlConnection(Constr);
            SqlCommand cmd = new SqlCommand("sp_GetDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet != null)
            {
                foreach (DataRow employee in dataSet.Tables[0].Rows)
                {
                    DepartmentModel departmentModel = new DepartmentModel();
                    departmentModel.ID = Convert.ToString(employee["ID"]); ;
                    departmentModel.Name = Convert.ToString(employee["Name"]);
                    departmentModels.Add(departmentModel);
                }
            }
            con.Close();
            return departmentModels;
        }

        public bool AddDepartment(DepartmentModel departmentModel)
        {
            SqlConnection con = new SqlConnection(Constr);
            SqlCommand cmd = new SqlCommand("sp_InsertDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", departmentModel.Name); 
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 0)
                return true;
            else
                return false;
        }


        public DepartmentModel GetDepartmentById(int Id)
        {
            DepartmentModel departmentModel = new DepartmentModel();
            SqlConnection con = new SqlConnection(Constr);
            SqlCommand cmd = new SqlCommand("sp_GetDeparmentByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Id);
            con.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            if (dataSet != null)
            {

                departmentModel.ID = Convert.ToString(dataSet.Tables[0].Rows[0]["ID"]);
                departmentModel.Name = Convert.ToString(dataSet.Tables[0].Rows[0]["Name"]); 
            }
            con.Close();
            return departmentModel;
        }
        public bool Update(DepartmentModel departmentModel)
        {
            SqlConnection con = new SqlConnection(Constr);
            SqlCommand cmd = new SqlCommand("sp_UpdateDeparment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", departmentModel.ID);
            cmd.Parameters.AddWithValue("@name", departmentModel.Name); 
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
            SqlCommand cmd = new SqlCommand("sp_DeleteDepartmentByID", con);
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