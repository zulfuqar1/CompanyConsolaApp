using Company.core.interfaces;

namespace Company.core.Entities;

public class corparation : IEntity
{
    public int id { get; }
    public string Name { get; set; }
    private static int _count;
    public List<Department> Departments { get; set; }

    private corparation()
    {
        id = _count++;
    }
    public corparation(string name) : this()
    {
        Name = name;
        Departments = new List<Department>();
    }
    public List<Department> GetAllDepartments() 
    {

        return Departments;
    }
    public override string ToString()
    {
        return $"Id: {id}, Name: {Name}";
    }
}
