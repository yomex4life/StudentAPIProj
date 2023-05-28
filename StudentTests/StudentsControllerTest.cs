using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentAPI.Controllers;
using StudentAPI.Models;
using StudentAPI.Repo;

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
    }
}