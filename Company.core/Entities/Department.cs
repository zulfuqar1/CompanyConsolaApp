using Company.core.interfaces;
using System.Xml.Linq;

namespace Company.core.Entities;

public class Department : IEntity
{
    public int id { get; }
    public int CorparationId { get; set; }
    public string Name { get; set; }

    public int EmployeeLimit { get;}
    public static int _count;
    private Department()
    {
        id=_count++;
    }
    public Department(string name, int employeeLimit, int corparationId) : this()
    {
        Name = name;
        EmployeeLimit = employeeLimit;
        CorparationId = corparationId;
    }
    public override string ToString()
    {
        return $"Name: {Name}, Limit: {EmployeeLimit}, corparation :{CorparationId}";
    }
    //public void UpdateDepartment(string newName, int newEmployeeLimit,int CorparationId)
    //{
    //    if (string.IsNullOrEmpty(newName) || newEmployeeLimit <= 0 || newCorparationId <= 0)
    //    {
    //        throw new ArgumentException("NewName and NewEmployeeLimit cannot be null or empty.");
    //    }
    //    Name = newName;
    //    EmployeeLimit = newEmployeeLimit;
    //    CorparationId = newCorparationId;
    //}

}
