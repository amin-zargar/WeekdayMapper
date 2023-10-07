using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using WeekDayMapper.Application.UseCases.Classes;

namespace WeekDayMapper.Application.Validations
{
    public class CreateClassACommandValidator : AbstractValidator<CreateClassACommand>
    {
        public CreateClassACommandValidator()
        {
            RuleFor(x => x.ClassA.FName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(x => x.ClassA.LName).NotNull().NotEmpty();
            RuleFor(x => x.ClassA.Weekday).NotNull().NotEmpty().IsInEnum();
        }
    }
}
