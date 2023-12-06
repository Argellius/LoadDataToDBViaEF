using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadFileToDatabase.Database
{
    //Třída zaměstnanec - pro databázi
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }
    }
}

