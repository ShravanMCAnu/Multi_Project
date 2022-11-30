using Department;
using Employee;

//See https://aka.ms/new-console-template for more information

int table = 0;

do
{
    Console.WriteLine("Hi Welcome to Database There Are Two Table you Can work on they are\n\n\t1.Employee Table\n\t2.Department Table\n\t3.Close DB ");
    table = int.Parse(Console.ReadLine());
    switch (table)
    {
        case 1:
            EmployeeExcecution obj1 = new EmployeeExcecution();
            obj1.EmployeeExcecutionMethod();
            
            break;
        case 2:
            DepartmentExecution obj2 = new DepartmentExecution();
            obj2.DepartmentExecutionMethod();
            break;
    }
}
while (table < 3);


Console.WriteLine("Database CLosed Press Enter to exit the Console");




