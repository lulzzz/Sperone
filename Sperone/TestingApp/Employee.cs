using System;
using System.Collections.Generic;
using System.Text;

namespace Sperone.Indexing
{
    [Serializable]
    class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {FirstName} {LastName}, Salary {Salary}";
        }
    }
}
