using BusinessServices.Interfaces.Validators;
using BusinessServices.Repositories;
using DataAccess.Interfaces;
using Models.DTOs;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Services
{
    public class EmployeeServiceTests
    {
        [Fact]
        public async Task GetAllEmployees_WithEmployees_ReturnsEmployees()
        {
            //Arrage
            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(repo => repo.GetAllEmployees())
                .ReturnsAsync(GetEmployees());

            var mockValidator = new Mock<IEmployeeValidator>();

            var service = new EmployeeService(mockRepo.Object, mockValidator.Object);

            //Act
            var result = await service.GetAllEmployees();

            //Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetAllEmployees_WithHourlyContract_ReturnsAnnualSalary()
        {
            //Arrage
            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(repo => repo.GetAllEmployees())
                .ReturnsAsync(GetEmployees());

            var mockValidator = new Mock<IEmployeeValidator>();

            var service = new EmployeeService(mockRepo.Object, mockValidator.Object);

            //Act
            var result = await service.GetAllEmployees();
            var hourlyContract = result.FirstOrDefault(x => x.ContractTypeName == "HourlySalaryEmployee");

            //Assert
            Assert.Equal(86400000, hourlyContract.AnnualSalary);
        }

        [Fact]
        public async Task GetAllEmployees_WithMonthlyContract_ReturnsAnnualSalary()
        {
            //Arrage
            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(repo => repo.GetAllEmployees())
                .ReturnsAsync(GetEmployees());

            var mockValidator = new Mock<IEmployeeValidator>();

            var service = new EmployeeService(mockRepo.Object, mockValidator.Object);

            //Act
            var result = await service.GetAllEmployees();
            var hourlyContract = result.FirstOrDefault(x => x.ContractTypeName == "MonthlySalaryEmployee");

            //Assert
            Assert.Equal(960000, hourlyContract.AnnualSalary);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetEmployeeById_WithEmployees_ReturnsEmployee(int id)
        {
            //Arrage
            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(repo => repo.GetAllEmployees())
                .ReturnsAsync(GetEmployees());

            var mockValidator = new Mock<IEmployeeValidator>();

            var service = new EmployeeService(mockRepo.Object, mockValidator.Object);

            //Act
            var result = await service.GetEmployeeById(id);

            //Assert
            Assert.Equal(id, result.Id);
        }

        [Theory]
        [InlineData(3)]
        public async Task GetEmployeeById_WithEmployees_ReturnsEmployeeNotFound(int id)
        {
            //Arrage
            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(repo => repo.GetAllEmployees())
                .ReturnsAsync(GetEmployees());

            var mockValidator = new Mock<IEmployeeValidator>();
            mockValidator.Setup(val => val.EntityNotNull(null)).Throws(new Exception("Employe not found"));

            var service = new EmployeeService(mockRepo.Object, mockValidator.Object);
            
            //Act
            Task act() => service.GetEmployeeById(id);

            //assert
            var exception = await Assert.ThrowsAsync<Exception>(act);
            Assert.Equal("Employe not found", exception.Message);

        }

        [Theory]
        [InlineData(1)]
        public async Task GetEmployeeById_WithEmployees_ReturnsContractTypeNotFound(int id)
        {
            //Arrage
            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(repo => repo.GetAllEmployees())
                .ReturnsAsync(GetEmployeesWithoutContract());

            var mockValidator = new Mock<IEmployeeValidator>();
            mockValidator.Setup(val => val.ContractNotNull(null)).Throws(new Exception("Contract type not found"));

            var service = new EmployeeService(mockRepo.Object, mockValidator.Object);

            //Act
            Task act() => service.GetEmployeeById(id);

            //assert
            var exception = await Assert.ThrowsAsync<Exception>(act);
            Assert.Equal("Contract type not found", exception.Message);

        }

        private List<EmployeeDTO> GetEmployees()
        {
            var employees = new List<EmployeeDTO>
            {
                new EmployeeDTO
                {
                    Id = 1,
                    ContractTypeName = "HourlySalaryEmployee",
                    Description = "",
                    HourlySalary = 60000,
                    MonthlySalary = 80000,
                    Name = "Juan",
                    RoleId = 1,
                    RoleName = "Admin"
                },
                new EmployeeDTO
                {
                    Id = 2,
                    ContractTypeName = "MonthlySalaryEmployee",
                    Description = "",
                    HourlySalary = 60000,
                    MonthlySalary = 80000,
                    Name = "Pedro",
                    RoleId = 2,
                    RoleName = "Contractor"
                }
            };
            return employees;
        }

        private List<EmployeeDTO> GetEmployeesWithoutContract()
        {
            var employees = new List<EmployeeDTO>
            {
                new EmployeeDTO
                {
                    Id = 1,
                    ContractTypeName = "",
                    Description = "",
                    HourlySalary = 60000,
                    MonthlySalary = 80000,
                    Name = "Juan",
                    RoleId = 1,
                    RoleName = "Admin"
                },
                new EmployeeDTO
                {
                    Id = 2,
                    ContractTypeName = "",
                    Description = "",
                    HourlySalary = 60000,
                    MonthlySalary = 80000,
                    Name = "Pedro",
                    RoleId = 2,
                    RoleName = "Contractor"
                }
            };
            return employees;
        }
    }
}
