using Company.core.Entities;
using Company.Infrastructure.DBContext;
using System.Data;

namespace Company.Infrastructure.Service;

public  class EmployeeService
{
    private static int index_counter = 0;
    public void Create(string name,string Surname, int Salary, int Department_id)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException();
        }
        bool isExist = false;
        for (int i = 0; i < index_counter; i++)
        {
            if (AppDBContext.employees[i].Name.ToUpper() == name.ToUpper())
            {
                isExist = true; break;
            }
        }
        if (isExist)
        {
            throw new DuplicateNameException(
                "this Department name alredy exist !\n" +
                "*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
        }
        Employee new_Employee = new(name, Surname,Salary,Department_id);
        AppDBContext.employees[index_counter++] = new_Employee;

    }
    public void GetAllEmplyee()
    {
        for (int i = 0; i < index_counter; i++)
        {
            Console.WriteLine("Id: " + AppDBContext.employees[i].id + " -> " + "name: " + AppDBContext.employees[i].Name);
        }
    }
}
