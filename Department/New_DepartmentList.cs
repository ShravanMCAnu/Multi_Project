using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department
{
    internal class New_DepartmentList : DB_Connection_Department
    {
        List<Dept_Properties> newList = new List<Dept_Properties>();
        public void DepartmentList()
        {
            SqlConnection sqlCon = new SqlConnection("Server=LAPTOP-BJF2P1AA;Database=DatabaseOne;Trusted_Connection=true;");
            sqlCon.Open();
            string query = "Select * from department";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    newList.Add(new Dept_Properties()
                    {
                        Department_id = (int)dr["Department_id"],
                        Department_Name = dr["Department_Name"].ToString(),
                        Department_shortName = dr["Department_shortName"].ToString()
                    });
                }
                sqlCon.Close();
            }
        }
        public void DisplayNewListItems()
        {
            foreach (var listItem in newList)
            {
                Console.WriteLine("Department ID : " + listItem.Department_id);
                Console.WriteLine("Department Name : " + listItem.Department_Name);
                Console.WriteLine("Department Short Name : " + listItem.Department_shortName);
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
