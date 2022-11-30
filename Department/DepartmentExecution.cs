
using System;

namespace Department
{
    public class DepartmentExecution
    {
        public void DepartmentExecutionMethod()
        {
            DB_Connection_Department objDB_Connection = new DB_Connection_Department();

            int choiceD = 0;
            objDB_Connection.InsertDept("insert into department values(@name,@short)");
            Console.WriteLine(" Firstly,\n\t   Department List inserted into DB sucessfully....");


            objDB_Connection.Inserting();
            objDB_Connection.Update();

            objDB_Connection.Delete();

            


          
            New_DepartmentList objNew_DepartmentList = new New_DepartmentList();
            objNew_DepartmentList.DepartmentList();
            objNew_DepartmentList.DisplayNewListItems();

            Console.WriteLine("Lastly\n\t" +
                "Department TAble values Added into the New List");

            Console.WriteLine("\nPress Enter to exit the table");

            objDB_Connection.DBClearD("department");
        }
    }
}
