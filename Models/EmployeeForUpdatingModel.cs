using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeRestAPI.Models
{
    public class EmployeeForUpdatingModel
    {
        [FromRoute]
        public int Id { get; set; }

        [Length(0, 30)]
        public string Position { get; set; }

        [Range(0,3000)]
        public int Salary { get; set; }
        public bool IsManager { get; set; }
    }

    public class EmployeeForUpdatingModelValidator : AbstractValidator<EmployeeForUpdatingModel>
    {
        public EmployeeForUpdatingModelValidator()
        {
            RuleFor(x => x.Salary).InclusiveBetween(0, 3000);
        }
    }
}
