using System;
using Ulvi_Asadzade___HRManagementSystem.Models;
using Ulvi_Asadzade___HRManagementSystem.Service;

namespace Ulvi_Asadzade___HRManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResurceManager humanResurceManager = new HumanResurceManager();
            
            string ans;
            do
            {
                Console.WriteLine("\n==============================================\n");

                Console.WriteLine("1.1 - Departmentlerin siyahisini goster");
                Console.WriteLine("1.2 - Yeni department yaratmaq");
                Console.WriteLine("1.3 - Department adinda deyisiklik etmek");
                Console.WriteLine("2.1 - Butun iscilerin siyahisini gostermek");
                Console.WriteLine("2.2 - Departmentdeki iscilerin siyahisini gostermek");
                Console.WriteLine("2.3 - Isci elave etmek");
                Console.WriteLine("2.4 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine("2.5 - Departmenden silmek istediyiniz iscinin adini yazin");
                Console.WriteLine("2.6 - Axtaris");
                Console.WriteLine("3 - sistemden cixis");

                Console.WriteLine("\nIcra etmek istediyiniz emeliyyati secin:");
                ans = Console.ReadLine();

                Console.WriteLine("\n==============================================\n");

                switch (ans)
                {
                    case "1.1":
                        ShowDepartments(humanResurceManager);
                        break;
                    case "1.2":
                        AddDepartment(humanResurceManager);
                        break;
                    case "1.3":
                        EditDepartment(humanResurceManager);
                        break;
                    case "2.1":
                        ShowAllEmployees(humanResurceManager);
                        break;
                    case "2.2":
                        ShowEmployeesOfDepartment(humanResurceManager);
                        break;
                    case "2.3":
                        AddEmployee(humanResurceManager);
                        break;
                    case "2.4":
                        EditEmployee(humanResurceManager);
                        break;
                    case "2.5":
                        RemoveEmployee(humanResurceManager);
                        break;
                    case "2.6":
                        SearchEmployee(humanResurceManager);
                        break;
                    default:
                        break;
                }

            } while (ans != "3");


        }

        static void ShowDepartments(HumanResurceManager humanResurceManager)
        {
            if (humanResurceManager.Departments.Length > 0)
            {
                foreach (var item in humanResurceManager.Departments)
                {
                    Console.WriteLine($"Departamentin adi: {item.Name} - Isci sayi: {item.Employees.Length} -  Maas ortalamasi: {item.CalcSalaryAverage(item)}");
                }
            }
            else
            {
                Console.WriteLine("Sistemde hecbir department movcud deyil");
            }
        }
        static void AddDepartment(HumanResurceManager humanResurceManager)
        {
            string name;
            bool check = true;
            do
            {
                if (check)
                {
                    Console.WriteLine("Department adini daxil edin:");
                }
                else
                {
                    Console.WriteLine("Department adinda reqem ola bilmez, ilk herfi boyuk olmali ve minimum 2 herfli olmalidir, yeniden daxil edin");
                }
                name = Console.ReadLine();
                check = false;

            } while (!humanResurceManager.CheckName(name));

            do
            {
                if (check)
                {
                    Console.WriteLine("Daxil etdiyiniz department movcuddur, yeniden daxil edin:");
                    name = Console.ReadLine();
                }
                check = true;

            } while (humanResurceManager.FindDepartmentByName(name) != null);


            int workerlimit;
            string workerlimitstr;
            check = true;
            do
            {
                if (check)
                {
                    Console.WriteLine("Departmentin isci limitini daxil edin");
                }
                else
                {
                    Console.WriteLine("Isci limitinde herf olmamalidir ve minimum isci limiti 1 olmalidir, yeniden daxil edin");
                }
                workerlimitstr = Console.ReadLine();
                check = false;

            } while (!int.TryParse(workerlimitstr, out workerlimit) || workerlimit <= 0);

            double salarylimit;
            string salarylimitstr;
            check = true;
            do
            {
                if (check)
                {
                    Console.WriteLine("Departmentin maas limitini daxil edin");
                }
                else
                {
                    Console.WriteLine("Maas limitinde herf olmamalidir ve maas limiti 250-den asagi ola bilmez, yeniden daxil edin");
                }
                salarylimitstr = Console.ReadLine();
                check = false;

            } while (!double.TryParse(salarylimitstr, out salarylimit) || salarylimit < 250);

            humanResurceManager.AddDepartment(name, workerlimit, salarylimit);
        }
        static void EditDepartment(HumanResurceManager humanResurceManager)
        {
            if (humanResurceManager.Departments.Length > 0)
            {
                string name;
                bool check = true;
                do
                {
                    if (check)
                    {
                        Console.WriteLine("Deyismek istediyiniz departmentin adini daxil edin:");
                    }
                    else
                    {
                        Console.WriteLine("Department adinda reqem ola bilmez, ilk herfi boyuk olmali ve minimum 2 herfli olmalidir, yeniden daxil edin");
                    }
                    name = Console.ReadLine();
                    check = false;

                } while (!humanResurceManager.CheckName(name));

                do
                {
                    if (check)
                    {
                        Console.WriteLine("Daxil etdiyiniz department movcud deyil, yeniden daxil edin:");
                        name = Console.ReadLine();
                    }
                    check = true;

                } while (humanResurceManager.FindDepartmentByName(name) == null);

                string newname;
                check = true;

                do
                {
                    if (check)
                    {
                        Console.WriteLine("Yeni department adini daxil edin:");
                    }
                    else
                    {
                        Console.WriteLine("Department adinda reqem ola bilmez, ilk herfi boyuk olmali ve minimum 2 herfli olmalidir, yeniden daxil edin");
                    }
                    newname = Console.ReadLine();
                    check = false;

                } while (!humanResurceManager.CheckName(newname));

                do
                {
                    if (check)
                    {
                        Console.WriteLine("Daxil etdiyiniz department movcuddur, yeniden daxil edin:");
                        newname = Console.ReadLine();
                    }
                    check = true;

                } while (humanResurceManager.FindDepartmentByName(newname) != null);

                humanResurceManager.EditDepartments(name, newname);
            }
            else
            {
                Console.WriteLine("Sistemde hecbir department movcud deyil");
            }
               
        }
        static void ShowAllEmployees(HumanResurceManager humanresurcemanager)
        {
            var employees = humanresurcemanager.GetAllEmployees();
            if (employees == null)
            {
                Console.WriteLine("====================================================\n");
                Console.WriteLine("Sistemde hec bir department ve isci movcud deyil");

            }
            else if (employees.Length > 0)
            {
                Console.WriteLine("==================");
                Console.WriteLine("Butun Isciler:\n");
                foreach (var emp in employees)
                {
                    Console.WriteLine(emp);
                }
            }
            else
            {
                Console.WriteLine("====================================================\n");
                Console.WriteLine("Sistemde hec bir isci movcud deyil!");
            }


        }
        static void ShowEmployeesOfDepartment(HumanResurceManager humanResurceManager)
        {
            if (humanResurceManager.Departments.Length <= 0)
            {
                Console.WriteLine("====================================================\n");
                Console.WriteLine("Sistemde hec bir department ve isci movcud deyil");
            }
            else
            {
                string name;
                bool check = true;
                Department department = null;
                do
                {
                    if (check)
                        Console.WriteLine("Iscileri gormek istediyiniz departmenti daxil edin:");
                    else
                        Console.WriteLine("Daxil etdiyiniz department movcud deyil, yeniden daxil edin:");

                    name = Console.ReadLine();
                    department = humanResurceManager.FindDepartmentByName(name);
                    check = false;

                } while (department == null);

                if (department.Employees.Length > 0)
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine($"{name} departmentindeki isciler:\n");
                    foreach (var emp in department.Employees)
                    {
                        Console.WriteLine(emp);
                    }
                }
                else
                {
                    Console.WriteLine("=================================\n");
                    Console.WriteLine("Secilmis departmentde hec bir isci yoxdur!");
                }
            }


        }
        static void AddEmployee(HumanResurceManager humanResurceManager)
        {
            if (humanResurceManager.Departments.Length <= 0)
            {
                Console.WriteLine("Sistemde hec bir department movcud deyil");
            }
            else
            {
                string departmentname;
                Department department = null;
                bool check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Isci elave etmek istediyiniz departmenti daxil edin:");
                    else
                        Console.WriteLine("Daxil etdiyiniz department movcud deyil, yeniden daxil edin:");

                    departmentname = Console.ReadLine();
                    department = humanResurceManager.FindDepartmentByName(departmentname);
                    check = false;

                } while (department == null);

                if (department.WorkerLimit <= department.Employees.Length)
                {
                    Console.WriteLine("Departmentin isci limiti doludur, isci elave ede bilmezsiniz!");
                    
                    return;
                }

                string fullname;
                check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Iscinin tam adini (ad, soyad seklinde) daxil edin:");
                    else
                        Console.WriteLine("Tam adi duzgun daxil edin");

                    fullname = Console.ReadLine();
                    check = false;

                } while (!humanResurceManager.CheckFullName(fullname));

                string position;
                check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Iscinin vezifesini daxil edin:");
                    else
                        Console.WriteLine("Vezife adi boyuk herfnen baslamali ve reqem olmamalidir, yeniden daxil edin");

                    position = Console.ReadLine();
                    check = false;

                } while (!humanResurceManager.CheckName(position));

                double salary;
                string salarystr;
                check = true;
                do
                {

                    if (check)
                        Console.WriteLine("Iscinin maasini daxil edin:");
                    else
                        Console.WriteLine("Maas yazarken herf olmamalidir ve maas 250den asagi olmamalidir, yeniden daxil edin");

                    salarystr = Console.ReadLine();
                    check = false;

                } while (!double.TryParse(salarystr, out salary) || salary < 250);

                if (department.TotalSalary(department) + salary > department.SalaryLimit)
                {
                    Console.WriteLine("Elave etmek istediyiniz iscinin maasi toplam limitten artiqdir");
                    return;
                }

                humanResurceManager.AddEmployee(departmentname, fullname, position, salary);
            }


        }
        static void EditEmployee(HumanResurceManager humanResurceManager)
        {
            if (humanResurceManager.Departments.Length <= 0)
            {
                Console.WriteLine("====================================================\n");
                Console.WriteLine("Sistemde hec bir department ve isci movcud deyil");
            }
            else
            {
                string departmentname;
                Department department = null;
                bool check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Deyisdirmek istediyiniz iscinin departmentini daxil edin:");
                    else
                        Console.WriteLine("Daxil etdiyiniz department movcud deyil, yeniden daxil edin:");

                    departmentname = Console.ReadLine();
                    department = humanResurceManager.FindDepartmentByName(departmentname);
                    check = false;

                } while (department == null);

                if (department.Employees.Length <= 0)
                {
                    Console.WriteLine("====================================================\n");
                    Console.WriteLine("Daxil etdiyiniz departmentde hecbir isci movcud deyil");
                    return;
                }
                else
                {
                    string no;
                    check = true;
                    do
                    {
                        if (check)
                            Console.WriteLine("Iscinin nomresini daxil edin:");
                        else
                            Console.WriteLine("Daxil etdiyiniz nomre yanlisdir, yeniden daxil edin");

                        no = Console.ReadLine();
                        check = false;

                        foreach (var item in department.Employees)
                        {
                            if (item.No == no)
                            {
                                Console.WriteLine($"Iscinin tam adi: {item.FullName} - Iscinin vezifesi: {item.Position} - Iscinin maasi: {item.Salary} ");
                                check = true;

                            }


                        }


                    } while (check == false);

                    string position;
                    check = true;
                    do
                    {
                        if (check)
                            Console.WriteLine("Iscinin yeni vezifesini daxil edin:");
                        else
                            Console.WriteLine("Vezife adinda reqem olmamalidir, yeniden daxil edin");

                        position = Console.ReadLine();
                        check = false;

                    } while (!humanResurceManager.CheckName(position));

                    double salary;
                    string salarystr;
                    check = true;
                    do
                    {

                        if (check)
                            Console.WriteLine("Iscinin yeni maasini daxil edin:");
                        else
                            Console.WriteLine("Maas yazarken herf olmamalidir ve maas 250den asagi olmamalidir, yeniden daxil edin");

                        salarystr = Console.ReadLine();
                        check = false;

                    } while (!double.TryParse(salarystr, out salary) || salary < 250);

                    humanResurceManager.EditEmployee(departmentname, no, position, salary);

                }

            }

        }
        static void RemoveEmployee(HumanResurceManager humanResurceManager)
        {

            if (humanResurceManager.Departments.Length <= 0)
            {
                Console.WriteLine("====================================================\n");
                Console.WriteLine("Sistemde hec bir department ve isci movcud deyil");
            }
            else
            {
                string departmentname;
                Department department = null;
                bool check = true;
                do
                {
                    if (check)
                        Console.WriteLine("Silmek istediyiniz iscinin departmentini daxil edin:");
                    else
                        Console.WriteLine("Daxil etdiyiniz department movcud deyil, yeniden daxil edin:");

                    departmentname = Console.ReadLine();
                    department = humanResurceManager.FindDepartmentByName(departmentname);
                    check = false;

                } while (department == null);

                if (department.Employees.Length <= 0)
                {
                    Console.WriteLine("====================================================\n");
                    Console.WriteLine("Daxil etdiyiniz departmentde hecbir isci movcud deyil");
                    return;
                }
                else
                {
                    string no;
                    check = true;
                    do
                    {
                        if (check)
                            Console.WriteLine("Silmek istediyiniz iscinin nomresini daxil edin:");
                        else
                            Console.WriteLine("Daxil etdiyiniz nomre yanlisdir, yeniden daxil edin");

                        no = Console.ReadLine();
                        check = false;

                        foreach (var item in department.Employees)
                        {
                            if (item.No == no)
                            {
                                check = true;

                            }


                        }

                    } while (check == false);

                    humanResurceManager.RemoveEmployee(no, departmentname);
                }

              
            }
        }
        static void SearchEmployee(HumanResurceManager humanResurceManager)
        {
            if (humanResurceManager.Departments.Length > 0)
            {
                string search;

                do
                {
                    Console.WriteLine("Axtaris deyerini daxil edin:");
                    search = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(search));

                var searchedEmployees = humanResurceManager.SearchEmployee(search);

                if (searchedEmployees.Length > 0)
                {
                    Console.WriteLine("Axtarisa uygun isciler: \n");
                    foreach (var item in searchedEmployees)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine("====================================================\n");
                    Console.WriteLine("Axtarisa uygun isci tapilmadi!");
                }
            }
            else
            {
                Console.WriteLine("====================================================\n");
                Console.WriteLine("Sistemde hecbir department ve isci movcud deyil");
            }
              
        }

    }    
}

