using LoadFileToDatabase.Csv;
using LoadFileToDatabase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadFileToDatabase
{
    //Managování databáze
    internal class ManagerDatabase
    {

        private Context context = null;

        public ManagerDatabase()
        {
            if (context == null) { 
                context = new Context();
            }
        }


        public Context GetContext()
        {
            return this.context;
        }

        public void AddEmployee(Employee emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();
        }

        public void AddEmployees(List<Employee> emps)
        {
            context.Employees.AddRange(emps);
            context.SaveChanges();
        }


        public List<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }


        //Pomocí delegátu získám data o zaměstnancích
        public void ProcessEmployees(CsvManager.LoadEmployeesDelegate loadEmployeesDelegate, string path)
        {
            List<Employee> employees = loadEmployeesDelegate.Invoke(path);

            AddEmployees(employees);
        }


    }
}
