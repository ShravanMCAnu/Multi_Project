using DB_Connection_All;
using System;
using System.Data.SqlClient;

namespace Employee
{
    public class DB_Connection_Employee : Employee_List
    {
        SqlConnection conn;
        SqlCommand cmd;
        string constr = "";
        public DB_Connection_Employee()
        {
            try
            {
                constr = DBConnections.conStr;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private SqlConnection DBConnection()
        {
            conn = new SqlConnection(constr);
            return conn;
        }


        public string InsertEmp(string query)
        {
            bool isDataInserted = true;
            var Emplist = EmployeeMethod();
            foreach (var emp in Emplist)
            {
                DBConnection();
                cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 100).Value = emp.Employee_Name;
                cmd.Parameters.Add("@Age", System.Data.SqlDbType.NVarChar, 100).Value = emp.Age;
                cmd.Parameters.Add("@Gender", System.Data.SqlDbType.NVarChar, 100).Value = emp.Gender;
                cmd.Parameters.Add("@DeptId", System.Data.SqlDbType.NVarChar, 100).Value = emp.Department_id;
                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    isDataInserted = false;
                    break;
                }
                conn.Close();
            }
            return isDataInserted == true ? "Firstly,\n\t Employee List inserted into DB sucessfully...." : "Falied";
        }

        public void Update()
        {

            Console.WriteLine("The Employee Table Values are:");
            SqlCommand cmd1 = new SqlCommand("select * from Employees", conn);
            conn.Open();
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(" " + reader.GetValue(i));

                }
                Console.WriteLine("------------------------------------------");
            }

            conn.Close();
            Console.WriteLine("Enter values into EmployeeID and EmployeeName You want to Update...");
            conn.Open();
            int EmployeeID = int.Parse(Console.ReadLine());
            string Employee_Name = Console.ReadLine();


            SqlCommand cmd2 = new SqlCommand("Update Employees set Employee_Name='" + Employee_Name + "' Where Employee_Id=" + EmployeeID + "", conn);

            cmd2.ExecuteNonQuery();
            Console.WriteLine("Updated Sucessfully");
            conn.Close();

            SqlCommand cmd3 = new SqlCommand("select * from Employees Where Employee_Id=" + EmployeeID + "", conn);
            conn.Open();
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                for (int i = 0; i < reader3.VisibleFieldCount; i++)
                {
                    Console.WriteLine("  " + reader3.GetValue(i));

                }
                Console.WriteLine("------------------------------------------");
            }
            conn.Close();

        }
        public void Delete()
        {

            Console.WriteLine("The Employee Table Values are:");
            SqlCommand cmd1 = new SqlCommand("select * from Employees", conn);
            conn.Open();
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(" " + reader.GetValue(i));

                }
                Console.WriteLine("------------------------------------------");
            }

            conn.Close();
            Console.WriteLine("Enter values into EmployeeID You want to delete");
            conn.Open();
            int EmployeeID = int.Parse(Console.ReadLine());



            SqlCommand cmd2 = new SqlCommand("delete from Employees  Where Employee_Id=" + EmployeeID + "", conn);

            cmd2.ExecuteNonQuery();
            Console.WriteLine("deleted Sucessfully");
            conn.Close();
        }


        public void Inserting()
        {
            Console.WriteLine("The Employee Table Values are:");
            SqlCommand cmd4 = new SqlCommand("select * from Employees", conn);
            conn.Open();
            SqlDataReader reader = cmd4.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(" " + reader.GetValue(i));

                }
                Console.WriteLine("------------------------------------------");
            }

            conn.Close();

            Console.WriteLine("Enter Employee Name ");
            string EmpName = Console.ReadLine();
            Console.WriteLine("Enter Employee Age");
            int EmpAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Employee Gender");
            string EmpGender = Console.ReadLine();
            Console.WriteLine("Enter Department ID Based on Employee");
            int EmpDeptID = int.Parse(Console.ReadLine());

            conn.Open();
            SqlCommand cmd5 = new SqlCommand("insert into  Employees values('" + EmpName + "', " + EmpAge + ", '" + EmpGender + "', " + EmpDeptID + ")", conn);
            cmd5.ExecuteNonQuery();
            conn.Close();

        }

        public void DBClearE()
        {
            SqlCommand cmdclear = new SqlCommand("truncate table Employees", conn);
            conn.Open();
            cmdclear.ExecuteNonQuery();
            conn.Close();
        }

    }
}
