using DB_Connection_All;
using System;
using System.Data.SqlClient;
namespace Department
{
    public class DB_Connection_Department : Department_List
    {
        SqlConnection conn;
        SqlCommand cmd;
        string constr = "";
        public DB_Connection_Department()
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

        private SqlConnection DBConnection( )
        {
            conn = new SqlConnection(constr);
            return conn;
        }
        public string InsertDept(string query)
        {
            DBConnection();
            bool isDataInserted = true;
            var dept_Lists = DepartmentMethod();
            foreach (var dept in dept_Lists)
            {
                DBConnection();
                cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 100).Value = dept.Department_Name;
                cmd.Parameters.Add("@short", System.Data.SqlDbType.NVarChar, 100).Value = dept.Department_shortName;
                
                int result =cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    isDataInserted = false;
                    break;
                }
                conn.Close();
            }
            return isDataInserted == true ? "Firstly,\n\t Department List inserted into DB sucessfully...." : "Falied";
        }
        public void Update()
        {
            Console.WriteLine("The Department Table Values are:");

            SqlCommand cmd1 = new SqlCommand("select * from department", conn);

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
            Console.WriteLine("Enter values into department ID and Department Name You want to Update...");
            conn.Open();
            int deptID = int.Parse(Console.ReadLine());
            string deptName = Console.ReadLine();

            SqlCommand cmd2 = new SqlCommand("Update department  set Department_Name ='" + deptName + "' Where Department_id=" + deptID + "", conn);

            cmd2.ExecuteNonQuery();
            Console.WriteLine("Updated Sucessfully");
            conn.Close();

            SqlCommand cmd3 = new SqlCommand("select * from department Where Department_id=" + deptID + "", conn);

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

            Console.WriteLine("The Department Table Values are:");

            SqlCommand cmd1 = new SqlCommand("select * from department", conn);

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
            Console.WriteLine("Enter values into departmentID You want to delete");
            conn.Open();
            int deptid = int.Parse(Console.ReadLine());

            SqlCommand cmd2 = new SqlCommand("delete from department  Where department_Id=" + deptid + "", conn);

            cmd2.ExecuteNonQuery();
            Console.WriteLine("deleted Sucessfully");
            conn.Close();
        }
        public void Inserting()
        {
            Console.WriteLine("The department Table Values are:");
            SqlCommand cmd4 = new SqlCommand("select * from department", conn);
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
            Console.WriteLine("Enter department  details you want to insert into databse..... ");
            Console.WriteLine("Enter department  Name ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter department shortName");
            string shortname = Console.ReadLine();
            conn.Open();
            SqlCommand cmd5 = new SqlCommand("insert into  department values('" + deptName + "','" + shortname + "')", conn);

           
            cmd5.ExecuteNonQuery();
            conn.Close();
        }
        public void DBClearD(string table)
        {
            string q = "truncate table " + table + "";
            SqlCommand cm = new SqlCommand(q, conn);
            conn.Open();
            cm.ExecuteNonQuery();
            conn.Close();
        }
    }
}
