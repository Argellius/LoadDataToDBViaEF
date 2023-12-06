using LoadFileToDatabase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadFileToDatabase.Csv
{
    //CSV manager
    public class CsvManager
    {
        public delegate List<Employee> LoadEmployeesDelegate(string path);

        //Vytáhne ze souboru data o zaměstnancích a vrátí je
        public static List<Employee> LoadEmployees(string path)
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (values.Length >= 3)
                        {
                            int id;
                            if (int.TryParse(values[0], out id))
                            {
                                var employee = new Employee
                                {
                                    Id = id,
                                    Name = values[1],
                                    Phone = values[2]
                                };

                                employees.Add(employee);
                            }
                            else
                            {
                                Console.WriteLine($"Invalid ID format: {values[0]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid line format: {line}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
            }

            return employees;
        }
    }
   
}
