using Employee;
using System;

namespace Department
{
    public class EmployeeExcecution
    {
        public void EmployeeExcecutionMethod()
        {
            DB_Connection_Employee db = new DB_Connection_Employee();
            string r = db.InsertEmp("insert into Employees values(@Name,@Age,@Gender,@DeptId)");
            Console.WriteLine(r);

            Console.WriteLine("   Employee List inserted into DB sucessfully....");


            db.Inserting();

            db.Update();

            db.Delete();

           




            db.DBClearE();


            New_EmployeeList newList = new New_EmployeeList();
            newList.EmployeeNewList();
            newList.DisplayNewListItems();

            Console.WriteLine("Lastly\n\tEmployee Table values Added into the New List");
            Console.WriteLine("\nPress Enter to exit the table");


        }
    }

}
