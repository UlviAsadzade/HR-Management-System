using System;
using System.Collections.Generic;
using System.Text;

namespace Ulvi_Asadzade___HRManagementSystem.Models
{
    class Department
    {
        public Department(string name, int workerlimit, double salarylimit)
        {
            this.Name = name;
            this.WorkerLimit = workerlimit;
            this.SalaryLimit = salarylimit;
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (CheckName(value))
                {
                    _name = value;
                }
                
            }
        }

        private int _workerLimit;
        public int WorkerLimit
        {
            get
            {
                return _workerLimit;
            }
            set
            {
                if (value > 0)
                {
                    _workerLimit = value;
                }
                
            }
        }

        private double _salaryLimit;
        public double SalaryLimit
        {
            get
            {
                return _salaryLimit;
            }
            set
            {
                if (value > 249)
                {
                    _salaryLimit = value;
                }
            }
        }
        public Employee[] Employees = new Employee[0];


        public double TotalSalary(Department department)
        {
            
             double totalsalary=0;
            foreach (var item in department.Employees)
            {
                totalsalary += item.Salary;
            }
            return totalsalary;
        }


        public  double CalcSalaryAverage(Department department)
        {
            double totalsalary = 0;
            int counter = 0;
            foreach (var item in department.Employees)
            {
                totalsalary += item.Salary;
                counter++;
            }
            return totalsalary / counter;

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
