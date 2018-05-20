using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Построить коллекцию сотрудников.
            var employees = new List<EmployeeID>
            {
                new EmployeeID {Id = "111", Name = "Ivan Ivanov"},
                new EmployeeID {Id = "222", Name = "Andrey Andreev"},
                new EmployeeID {Id = "333", Name = "Petr Petrov"},
                new EmployeeID {Id = "444", Name = "Alex Alexeev"}
            };

            // Построить коллекцию национальностей.
            var empNationalities = new List<EmployeeNationality>
            {
                new EmployeeNationality {Id = "111", Nationality = "Russian"},
                new EmployeeNationality {Id = "222", Nationality = "Kanadian"},
                new EmployeeNationality {Id = "333", Nationality = "American"},
                new EmployeeNationality {Id = "333", Nationality = "Russian"},
            };

            var query = from emp in employees
                        from n in empNationalities
                        where emp.Id == n.Id
                        select new
                        {
                            Id = emp.Id,
                            Name = emp.Name,
                            Nationality = n.Nationality
                        };

            var query2 = from m in query
                         group m by m.Nationality;

            foreach (var person in query2)
            {
                Console.WriteLine(person.Key);

                foreach (var item in person)
                {
                    Console.WriteLine(item.Id + " " + item.Name + " " + item.Nationality);
                }
                Console.WriteLine();          
            }
                

            // Delay.
            Console.ReadKey();
        }
    }

    public class EmployeeID
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class EmployeeNationality
    {
        public string Id { get; set; }
        public string Nationality { get; set; }
    }
}
