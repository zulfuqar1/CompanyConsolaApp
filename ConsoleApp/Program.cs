using Company.core.Entities;
using Company.Infrastructure.DBContext;
using Company.Infrastructure.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        CompanyService companyService = new CompanyService();
        DepartmentService departmentService = new DepartmentService();
        EmployeeService EmployeeService = new EmployeeService();


        Console.WriteLine("Welcome");
        while (true)
        {

            {
                Console.WriteLine
                    ("0 => Exit\n" +
                    "1 => Create Company\n" +
                    "2 => Company info\n" +
                    "3 => Create Department\n" +
                    "4 => Department info\n" +
                    "5 => Create Employee\n" +
                    "6 => Employee info\n" +
                    "****************************************\n");

                string? response = Console.ReadLine();
                int menu;
                bool tryToint = int.TryParse(response, out menu);
                if (tryToint)
                {

                    switch (menu)
                    {

                        case 0://Exti
                            Environment.Exit(0);
                            break;
                        case 1://Create Company
                            Console.WriteLine("Ente Company Name:");
                            string? res_CompanyName = Console.ReadLine();
                            try
                            {
                                companyService.Create(res_CompanyName);
                                Console.WriteLine($"new company : {res_CompanyName} ");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case 2://Company info                    
                            Console.WriteLine("Company list : ");
                            companyService.GetAllCorparation();
                            break;

                        case 3://Create Department
                            Console.WriteLine("enter Department name");
                            string Department_name = Console.ReadLine();
                            if(Department_name == null)
                            {
                                Console.WriteLine("Departament Name Can't be Null !!");
                                goto case 3 ;

                            }

                        max_count:
                            Console.WriteLine("enter Department limit");
                            string EmployeeLimit = Console.ReadLine();


                            int max_count;
                            bool tryToIntMax = int.TryParse(EmployeeLimit, out max_count);
                            if (!tryToIntMax)
                            {
                                Console.WriteLine("Enter correct Format");
                                goto max_count;
                            }



                        select_Corparation:

                            Console.WriteLine("enter Corparation (Id)");

                            companyService.GetAllCorparation();

                            string? selected_Corparation = Console.ReadLine();

                            int Corparation_id;

                            bool tryToIdCorparation = int.TryParse(selected_Corparation, out Corparation_id);

                            if (!tryToIdCorparation)
                            {
                                Console.WriteLine("Enter correct corparation Id");
                                goto select_Corparation;
                            };

                            try
                            {
                                departmentService.Create(Department_name,max_count, Corparation_id);
                                Console.WriteLine("Departmet created");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                goto case 3;
                            }
                            break;
                        case 4://Department info
                            Console.WriteLine("Department list:");
                            departmentService.GetAllDepartment();

                            break;

                        case 5://Create Employee
                      
                    Employe_Name:
                            
                            Console.WriteLine("enter Employee name");
                            string Employe_name = Console.ReadLine();

                    Employe_Surname:
                            
                            Console.WriteLine("enter Employee Surname");
                            string Employe_Surname = Console.ReadLine();

                    Employe_Salary:
                            
                            Console.WriteLine("entet Salary");
                            string? Employe_Salary = Console.ReadLine();

                            int Salary;

                            bool tryToSalary = int.TryParse(Employe_Salary, out Salary);
                            if (!tryToSalary)
                            {
                                Console.WriteLine("Enter correct Format");
                            };

                    departmen_id:
                            Console.WriteLine("entet Department id");
                            departmentService.GetAllDepartment();
                            string? departmentId = Console.ReadLine();

                            int Department_id;

                            bool tryToIdDepartment = int.TryParse(departmentId, out Department_id);
                            if (!tryToSalary)
                            {
                                Console.WriteLine("Enter correct Department Id");
                            };
                            try
                            {
                                EmployeeService.Create(Employe_name, Employe_Surname, Salary, Department_id);
                                Console.WriteLine("Employee Created...");
                            }
                            catch (Exception ex)
                            {
                                
                                Console.WriteLine(ex.Message);
                            }
                            

                            break;

                        case 6:// Employee info
                            break;
                            Console.WriteLine("employe list");
                            EmployeeService.GetAllEmplyee();  

                        default:
                            Console.WriteLine("Enter correct menu item!\n" +
                                "*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Enter correct menu item!\n" +
                        "*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                }
            }
        }
    }
}