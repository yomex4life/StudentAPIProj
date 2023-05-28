using System.Collections.Generic;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentAPI.Controllers;
using StudentAPI.Models;
using StudentAPI.Repo;
using StudentTests.Fixtures;

namespace StudentTests
{
    public class StudentsControllerTest
    {
        private readonly Mock<IStudentRepo> repoMock = new();
        private readonly Mock<IMapper> mapperStub = new();
        [Fact]

        public async Task GetStudentById_WhenCalled_ReturnsOkResult()
        {
            // Arrange
           
            repoMock.Setup(repo => repo.GetStudentById(1)).ReturnsAsync(new Student());
            var controller = new StudentsController(repoMock.Object, mapperStub.Object);

            // Act
            var result = await controller.GetStudentById(1);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetStudentById_WhenCalled_ReturnsNotFoundResult()
        {
            // Arrange
            repoMock.Setup(repo => repo.GetStudentById(1)).ReturnsAsync((Student)null);
            var controller = new StudentsController(repoMock.Object, mapperStub.Object);

            // Act
            var result = await controller.GetStudentById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        // [Fact]
        // public async Task GetItemAsync_withExistingItem_ReturnsExpectedItem()
        // {
        //     // Arrange
        //     var expectedItem = StudentFixture.GetStudents().First();
        //     repoMock.Setup(repo => repo.GetStudentById(1))
        //         .ReturnsAsync(expectedItem);
        //     var controller = new StudentsController(repoMock.Object, mapperStub.Object);

        //     // Act
        //     var result = await controller.GetStudentById(1);

        //     // Assert
        //     Assert.IsType<ActionResult<Student>>(result.Value);
        //     var model = (result as ActionResult<Student>).Value;
        //     Assert.Equal(expectedItem, model);
        //     // Console.WriteLine(actionResult.Value);
        //     // var model = Assert.IsType<Student>(actionResult.Value);
        //     // //var model2 = (result as ActionResult<Student>).Value;
        //     // Assert.Equal(expectedItem, model);
        // }

        [Fact]
        public async Task Get_OnSuccess_ReeturnsListOfStudents()
        {
            // Arrange
            var expectedItems = StudentFixture.GetStudents();
            repoMock.Setup(repo => repo.GetAllStudents())
                .ReturnsAsync(expectedItems);
            var controller = new StudentsController(repoMock.Object, mapperStub.Object);

            // Act
            var result = await controller.GetAllStudents();

            // Assert
            result.Should().BeOfType<ActionResult<List<Student>>>();            
        }
    }
}