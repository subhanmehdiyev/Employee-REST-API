using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeRestAPI.Data.Entities
{
    public class Employee
    {
        public int ID { get; set; }

        [Length(0,30)]
        public string Name { get; set; }

        [Length(0,30)]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [MaybeNull]
        public DateTime Birthdate { get; set; }

        [Length(0,30)]
        public string Position { get; set; }

        [MaybeNull]
        public int Salary { get; set; }

        [MaybeNull]
        public bool IsManager { get; set; }
    }
}
