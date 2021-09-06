using System;
using System.Collections.Generic;
using System.Text;

namespace Ulvi_Asadzade___HRManagementSystem.Models
{
    class Employee
    {
        public static int Total=1000;
        public Employee(string departmentname)
        {
            
            StringBuilder sb = new StringBuilder();
            DepartmentName = departmentname;
            Total++;
            sb.Append(Char.ToUpper(departmentname[0]));
            sb.Append(Char.ToUpper(departmentname[1]));
            No = sb + Total.ToString();
        }

        public  string No;
        private string _fullName;
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (CheckFullName(value))
                {
                    _fullName = value;
                }
                else
                {
                    _fullName = null;
                }
            }
        }

        private string _position;
        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (CheckName(value))
                {
                   _position = value;
                }
                else
                {
                    _position = null;
                }
            }
        }

        private double _salary;
        public double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if ( value >= 250)
                {
                    _salary = value;
                }
                
            }
        }

        public string DepartmentName;

        public static bool CheckFullName(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                var words = str.Split(" ");
                if (words.Length > 1)
                {
                    foreach (var word in words)
                    {
                        if (string.IsNullOrWhiteSpace(word))
                        {
                            return false;
                        }

                        foreach (var chr in word)
                        {
                            if (Char.IsLetter(chr) == false)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return $"FullName: {FullName}  - Nomresi: {No} - Departmenti: {DepartmentName}  - Vezifesi: {Position}  - Maasi: {Salary}";
        }

        public bool CheckName(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                if (str.Length > 1)
                {
                    if (Char.IsUpper(str[0]))
                    {
                        foreach (var chr in str)
                        {
                            if (Char.IsLetter(chr) == false)
                            {
                                return false;

                            }
                        }
                        return true;
                    }

                }
            }

            return false;
        }
    }
}
