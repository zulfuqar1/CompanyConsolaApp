using Company.core.Entities;
using Company.Infrastructure.DBContext;
using System.Data;
using System.Threading.Channels;
using System.Xml.Linq;

namespace Company.Infrastructure.Service;


public class CompanyService
{
    private static int index_counter = 0;
    public void Create(string? name)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException();
        }
        bool isExist = false;
        for (int i = 0; i < index_counter; i++)
        {
            if (AppDBContext.corparations[i].Name.ToUpper() == name.ToUpper())
            {
                isExist = true;break;
            }
        }
        if (isExist)
        {
            throw new DuplicateNameException(
                "this Company name alredy exist !\n" +
                "*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
        }
        corparation new_Corparation = new(name);
        AppDBContext.corparations[index_counter++] = new_Corparation;
    }


    public void GetAllCorparation()
    {
        for (int i = 0; i < index_counter; i++)
        {
            Console.WriteLine("Id: "+AppDBContext.corparations[i].id+" -> " +"name: "+AppDBContext.corparations[i].Name);
        }
    }


}
