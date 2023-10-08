using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using WeekDayMapper.Domain.DTOs;
using WeekDayMapper.Domain.Entities;
using WeekDayMapper.WebAPI.Controllers;
using Xunit;

namespace WeekDayMapper.Tests
{
    public class WeekdaysControllerTests
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public WeekdaysControllerTests()
        {
            _mapper = A.Fake<IMapper>();
            _mediator = A.Fake<IMediator>();
        }

        [Fact]
        public async Task WeekdaysController_GetAll_ReturnOK()
        {
            // Arrange
            var controller = new WeekdaysController(_mapper, _mediator);

            // Act
            var results = await controller.GetAll();

            // Assert
            results.Should().NotBeNull();
            results.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async Task GetAll_WhenThereAreWeekdays_ShouldReturnActionResultOfClassBWith200StatusCode()
        {
            // Arrange 
            var listOfClassA = A.Fake<ICollection<Domain.Entities.ClassA>>();
            var listofClassB = A.Fake<List<ClassB>>();
            A.CallTo(() => _mapper.Map<List<ClassB>>(listOfClassA)).Returns(listofClassB);
            var controller = new WeekdaysController(_mapper, _mediator);

            // Act
            var result = await controller.GetAll() as OkObjectResult;

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsAssignableFrom<List<ClassB>>(objectResult.Value);
            data.Count.Should().Be(listOfClassA.Count);
            objectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
