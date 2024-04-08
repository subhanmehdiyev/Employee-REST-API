using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace EmployeeRestAPI.Models
{
    public class EmployeeModel
    {
        [FromRoute]
        public int Id { get; set; }

        [Required]
        [MaxLength(30,ErrorMessage = "Name length must be not greater than 30")]
        public string Name { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Surname length must be not greater than 30")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Length(0, 30)]
        public string Position { get; set; }

        [Range(0,3000)]
        public int Salary { get; set; }
        public bool IsManager { get; set; }
    }

    public class EmployeeModelValidator : AbstractValidator<EmployeeModel>
    {
        public EmployeeModelValidator() 
        {
            RuleFor(x => x.Name).MaximumLength(30);
            RuleFor(x=>x.Surname).MaximumLength(30);
            RuleFor(x=>x.Salary).InclusiveBetween(0, 3000);
        }
    }
}
