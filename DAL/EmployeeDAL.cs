using Microsoft.Extensions.Configuration;
using ProjectEmployee.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEmployee.DAL
{
    public class EmployeeDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public EmployeeDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> employeelist = new List<Employee>();
            String qry = "select * from Employee";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee employee = new Employee();
                    employee.eid = Convert.ToInt32(dr["eid"]);//Id name same as per table in db
                    employee.ename = dr["ename"].ToString();
                    employee.dept = dr["dept"].ToString();
                    employee.salary = Convert.ToInt32(dr["salary"]);
                    employee.age = Convert.ToInt32(dr["age"]);
                    employee.gender = dr["gender"].ToString();
                    employee.password = dr["password"].ToString();
                    employeelist.Add(employee);

                }
            }
            con.Close();
            return employeelist;
        }

        public Employee GetEmployeeById(int eid)
        {
            Employee employee = new Employee();
            String qry = "select * from Employee where Id=@eid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", eid);

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    employee.eid = Convert.ToInt32(dr["eid"]);//Id name same as per table in db
                    employee.ename = dr["ename"].ToString();
                    employee.dept = dr["dept"].ToString();
                    employee.salary = Convert.ToInt32(dr["salary"]);
                    employee.age = Convert.ToInt32(dr["age"]);
                    employee.gender = dr["gender"].ToString();
                    employee.password = dr["password"].ToString();


                }
            }
            con.Close();
            return employee;

        }

        public int AddEmployee(Employee emp)
        {
            string qry = "insert into Employee values(@eid,@ename,@dept,@salary,@age,@gender)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@eid", emp.Id);
            cmd.Parameters.AddWithValue("@ename", emp.ename);
            cmd.Parameters.AddWithValue("@dept", emp.dept);
            cmd.Parameters.AddWithValue("@salary", emp.salary);
            cmd.Parameters.AddWithValue("@age", emp.age);
            cmd.Parameters.AddWithValue("@gender", emp.gender);
            cmd.Parameters.AddWithValue("@password", emp.password);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int UpdateEmployee(Employee emp)
        {
            string qry = "update Employee set @eid,@ename,@dept,@salary,@age,@gender where Id=@eid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@eid", emp.Id);
            cmd.Parameters.AddWithValue("@ename", emp.ename);
            cmd.Parameters.AddWithValue("@dept", emp.dept);
            cmd.Parameters.AddWithValue("@salary", emp.salary);
            cmd.Parameters.AddWithValue("@age", emp.age);
            cmd.Parameters.AddWithValue("@gender", emp.gender);
            cmd.Parameters.AddWithValue("@password", emp.password);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int DeleteEmployee(int eid)
        {
            string qry = "delete from Employee where Id=@eid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", eid);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

    }
}
