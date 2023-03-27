using Company.core.Entities;

namespace Company.Infrastructure.DBContext;

public static class AppDBContext
{
    public static Employee[] employees { get; set; } = new Employee[1000];
    public static Department[] departments { get; set; } = new Department[100];
    public static corparation[] corparations { get; set; } = new corparation[100];


}
