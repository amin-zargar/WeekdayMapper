using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using WeekDayMapper.Application.Repositories;
using WeekDayMapper.Application.UseCases.Classes;
using WeekDayMapper.Domain.Entities;
using WeekDayMapper.Domain.Enums;
using Xunit;

namespace WeekDayMapper.Tests.Commands
{
    public class CreateClassACommandHandlerTests
    {
        private readonly IClassARepository _classARepository;

        public CreateClassACommandHandlerTests()
        {
            _classARepository = A.Fake<IClassARepository>();
        }

        [Fact]
        public async Task Handle_Should_ReturnFailureResult_WhenFNameIsEmpty()
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
            var handler = new CreateClassACommandHandler(_classARepository);
            // Act
            var results = await handler.Handle(command, default);

            //Assert
            results.Should().BeNull();
        }
    }
}
