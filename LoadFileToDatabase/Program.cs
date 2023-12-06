// See https://aka.ms/new-console-template for more information

using LoadFileToDatabase;
using LoadFileToDatabase.Csv;
using LoadFileToDatabase.Database;


CsvManager csvManager = new CsvManager();
ManagerDatabase managerDatabase = new ManagerDatabase();

//Chycení delegátu
CsvManager.LoadEmployeesDelegate loadEmployeesDelegate = CsvManager.LoadEmployees;

managerDatabase.AddEmployee(new Employee() { Id = 111, Name = "asd", Phone = "123456" });


// Získání cesty k kořenovému adresáři projektu
var rootDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.FullName;
string dataFolderPath = Path.Combine(rootDirectory, "Data");
string csvFilePath = Path.Combine(dataFolderPath, "employees.csv");


//Zavolání delegátu
managerDatabase.ProcessEmployees(loadEmployeesDelegate, csvFilePath);

//Získání zaměstnancl z databáze
List<Employee> employees = managerDatabase.GetEmployees();


//Tisk na výstup
foreach (var employee in employees)
{
    Console.WriteLine($"Processed Employee - ID: {employee.Id}, Name: {employee.Name}, Phone: {employee.Phone}");
}




