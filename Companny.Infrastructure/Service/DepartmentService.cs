using Company.core.Entities;
using Company.Infrastructure.DBContext;
using System.Data;
using System.Xml.Linq;

namespace Company.Infrastructure.Service;

public class DepartmentService
{
    private static int index_counter = 0;
    public void Create(string name,int max_Departmet,int corparation_id)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException();
        }
        bool isExist = false;
        for (int i = 0; i < index_counter; i++)
        {
            if (AppDBContext.departments[i].Name.ToUpper() == name.ToUpper())
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
        Department new_department = new(name, max_Departmet, corparation_id);
        AppDBContext.departments[index_counter++]=new_department;
    }
    public void GetAllDepartment()
    {

        for (int i = 0; i < index_counter; i++)
        {
            string temp_corparation =string.Empty;
            foreach (var corparation in AppDBContext.corparations)
            {
                if (corparation == null) break;
                if (AppDBContext.departments[i].CorparationId == corparation.id)
                {
                    temp_corparation = corparation.Name;

                    break; 
                }
            }
            Console.WriteLine(
                $"- Id: {AppDBContext.departments[i].id} " +
                $"- Department: {AppDBContext.departments[i].Name} " +
                $"- Employee Limit: {AppDBContext.departments[i]. EmployeeLimit } " +
                $"- Belongs to : {temp_corparation} ");
        }
    }
}
