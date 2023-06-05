using Castle.Core.Resource;
using FamilyBudget.Api.Controllers;
using FamilyBudget.Api.Model;
using FamilyBudget.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.ControllersTests
{
    [TestClass]
    public class BudgetControllerTests
    {
        Budget budget1;
        Budget budget2;

        public BudgetControllerTests() 
        {
            budget1 = new Budget() { Id = 1, Name = "budget1", Amount = 11 };
            budget2 = new Budget() { Id = 2, Name = "budget2", Amount = 11 };
        }

        [TestMethod]
        public async Task GetAll_NoParams()
        {
            //Arrange
            Mock<BudgetRepository> repoMock = new Mock<BudgetRepository>(null);
            repoMock.Setup(e => e.GetAll(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(Task.FromResult<List<Budget>>( new List<Budget>() { budget1, budget2 } ));

            //Act
            BudgetController budgetController = new BudgetController(null, repoMock.Object);
            var result = await budgetController.Get();


            //Assert
            repoMock.VerifyAll();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            var retList = result.Value;
            Assert.AreEqual(2, retList.Count());
            Assert.AreEqual(budget1, retList.First());
            Assert.AreEqual(budget2, retList.Last());
        }

        [TestMethod]
        public async Task GetAll_WithParams()
        {
            //Arrange
            Mock<BudgetRepository> repoMock = new Mock<BudgetRepository>(null);
            repoMock.Setup(e => e.GetAll(It.Is<int>(x => x == 2), It.Is<int>(x => x == 1)))
            .Returns(Task.FromResult<List<Budget>>(new List<Budget>() { budget2 }));

            //Act
            BudgetController budgetController = new BudgetController(null, repoMock.Object);
            var result = await budgetController.Get(2, 1);


            //Assert
            repoMock.VerifyAll();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            var retList = result.Value;
            Assert.AreEqual(1, retList.Count());
            Assert.AreEqual(budget2, retList.First());
        }

        [TestMethod]
        public async Task Get_Found()
        {
            //Arrange
            Mock<BudgetRepository> repoMock = new Mock<BudgetRepository>(null);
            repoMock.Setup(e => e.Get(It.Is<int>(x => x == 2)))
            .Returns(Task.FromResult<Budget>( budget2 ));

            //Act
            BudgetController budgetController = new BudgetController(null, repoMock.Object);
            var result = await budgetController.Get(2);


            //Assert
            repoMock.VerifyAll();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(budget2, result.Value);
        }

        [TestMethod]
        public async Task Get_NotFound()
        {
            //Arrange
            Mock<BudgetRepository> repoMock = new Mock<BudgetRepository>(null);
            repoMock.Setup(e => e.Get(It.Is<int>(x => x == 2)))
            .Returns(Task.FromResult<Budget>(null));

            //Act
            BudgetController budgetController = new BudgetController(null, repoMock.Object);
            var result = await budgetController.Get(2);


            //Assert
            repoMock.VerifyAll();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Put_NoContent()
        {
            //Arrange
            Mock<BudgetRepository> repoMock = new Mock<BudgetRepository>(null);
            repoMock.Setup(e => e.Update(It.Is<Budget>(x => x == budget1)))
            .Returns(Task.FromResult<Budget>(budget1));

            //Act
            BudgetController budgetController = new BudgetController(null, repoMock.Object);
            var result = await budgetController.Put(1, budget1);


            //Assert
            repoMock.VerifyAll();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task Put_Badrequest()
        {
            //Arrange
            Mock<BudgetRepository> repoMock = new Mock<BudgetRepository>(null);
            repoMock.Setup(e => e.Update(It.Is<Budget>(x => x == budget1)))
            .Returns(Task.FromResult<Budget>(budget1));

            //Act
            BudgetController budgetController = new BudgetController(null, repoMock.Object);
            var result = await budgetController.Put(2, budget1);


            //Assert
            repoMock.VerifyNoOtherCalls();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }


        [TestMethod]
        public async Task Post_Success()
        {
            //Arrange
            Mock<BudgetRepository> repoMock = new Mock<BudgetRepository>(null);
            repoMock.Setup(e => e.Add(It.Is<Budget>(x => x == budget1)))
            .Returns(Task.FromResult<Budget>(budget1));

            //Act
            BudgetController budgetController = new BudgetController(null, repoMock.Object);
            var result = await budgetController.Post(budget1);


            //Assert
            repoMock.VerifyAll();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));
        }

        [TestMethod]
        public async Task Delete_Success()
        {
            //Arrange
            Mock<BudgetRepository> repoMock = new Mock<BudgetRepository>(null);
            repoMock.Setup(e => e.Delete(It.Is<int>(x => x == 2)))
            .Returns(Task.FromResult<Budget>(budget2));

            //Act
            BudgetController budgetController = new BudgetController(null, repoMock.Object);
            var result = await budgetController.Delete(2);


            //Assert
            repoMock.VerifyAll();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(budget2, result.Value);
        }

        [TestMethod]
        public async Task Delete_NotFound()
        {
            //Arrange
            Mock<BudgetRepository> repoMock = new Mock<BudgetRepository>(null);
            repoMock.Setup(e => e.Delete(It.Is<int>(x => x == 2)))
            .Returns(Task.FromResult<Budget>(null));

            //Act
            BudgetController budgetController = new BudgetController(null, repoMock.Object);
            var result = await budgetController.Delete(2);


            //Assert
            repoMock.VerifyAll();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }
    }
}
