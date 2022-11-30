using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Employee
{
    public class New_EmployeeList:DB_Connection_Employee
    {
        List<Employee_Properties> newList = new List<Employee_Properties>();
        public void EmployeeNewList()
        {
            SqlConnection sqlCon = new SqlConnection("Server=LAPTOP-BJF2P1AA;Database=DatabaseOne;Trusted_Connection=true;");
            sqlCon.Open();
            string query = "Select * from Employees";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    newList.Add(new Employee_Properties()
                    {
                        EmployeeID = (int)dr["Employee_Id"],
                        Employee_Name = dr["Employee_Name"].ToString(),
                        Age = (int)dr["Age"],
                        Gender = dr["Gender"].ToString(),
                        Department_id = (int)(decimal)dr["Department_id"]
                        
                    });
                }
                sqlCon.Close();
            }
        }
        public void DisplayNewListItems()
        {
            foreach (var listItem in newList)
            {
                Console.WriteLine("Employee ID : " + listItem.EmployeeID);
                Console.WriteLine("Employee Name : " + listItem.Employee_Name);
                Console.WriteLine("Employee Age : " + listItem.Age);
                Console.WriteLine("Employee Gender : " + listItem.Gender);
                Console.WriteLine("Employee Dept ID : " + listItem.Department_id);
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
