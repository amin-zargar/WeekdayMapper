using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using FluentValidation.TestHelper;
using WeekDayMapper.Application.UseCases.Classes;
using WeekDayMapper.Application.Validations;
using WeekDayMapper.Domain.Entities;
using WeekDayMapper.Domain.Enums;
using Xunit;

namespace WeekDayMapper.Tests.Validators
{
    public class CreateClassACommandValidatorTests
    {
        private readonly CreateClassACommandValidator _validator;

        public CreateClassACommandValidatorTests()
        {
            _validator = new CreateClassACommandValidator();
        }

        [Fact]
        public void Should_HaveError_WhenFNameIsEmpty()
        {
            // Arrange
            var classA = new ClassA()
            {
                Id = Guid.NewGuid(),
                FName = string.Empty,
                LName = "Test",
                Weekday = Weekday.Friday
            };

            var command = new CreateClassACommand() { ClassA = classA };

            // Act
            var results = _validator.TestValidate(command);

            //Assert
            results.ShouldHaveValidationErrorFor(x => x.ClassA.FName);
        }
    }
}
