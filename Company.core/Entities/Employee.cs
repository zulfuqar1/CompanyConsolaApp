using Company.core.interfaces;

namespace Company.core.Entities;

public class Employee : IEntity
{
    public int id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Salary { get; set; }
    public int DepartmenId { get; set; }
    private static int _count { get; set; }

     private Employee()
    {
        id= _count++;
    }
    public Employee(string name, string surname, int salary,int departmenId):this()
    {
       Name = name;
        Surname = surname;
        Salary = salary;
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}
