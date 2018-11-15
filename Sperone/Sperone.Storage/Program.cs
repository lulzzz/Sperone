using Sperone.Base;
using Sperone.Indexing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sperone.Storage
{
    class Program
    {

        public static void Main(string[] args)
        {
            var emp1 = new Employee { Id = 1, FirstName = "John", LastName = "Smith", Salary = new decimal(100000) };
            var emp2 = new Employee { Id = 2, FirstName = "Steve", LastName = "Barret", Salary = new decimal(150000) };

            var id = new DocumentId();

            var storage = new Storage<Employee>();

            for (int i = 0; i < 1000; i++)
            {
                storage.Save(emp1);
            }


            var all = storage.All().ToArray();
        }
    }
}