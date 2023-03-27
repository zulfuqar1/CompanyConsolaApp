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
                "this Employee alredy exist !\n" +
                "*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
        }
        Employee new_Employee = new(name, Surname,Salary,Department_id);
        AppDBContext.employees[index_counter++] = new_Employee;

    }
    public void GetAllEmplyee()
    {
        for (int i = 0; i < index_counter; i++)
        {
            string temp_department = string.Empty;
            foreach (var department in AppDBContext.corparations)
            {
                if (department == null) break;
                if (AppDBContext.employees[i].DepartmenId == department.id)
                {
                    temp_department = department.Name;

                    break;
                }
            }
            Console.WriteLine(
                $"- Id: {AppDBContext.employees[i].id} " +
                $"- Name: {AppDBContext.employees[i].Name} " +
                $"- Surname: {AppDBContext.employees[i].Surname} " +
                $"- Salary: {AppDBContext.employees[i].Salary} " +
                $"- department : {temp_department} ");
        }
        //    for (int i = 0; i < index_counter; i++)
        //    {
        //        Console.WriteLine("Id: " + AppDBContext.employees[i].id + " -> " + "name: " + AppDBContext.employees[i].Name);
        //    }
    }
}
