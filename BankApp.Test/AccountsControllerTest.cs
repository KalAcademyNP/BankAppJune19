using BankUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BankApp.Test
{
    [TestClass]
    public class AccountsControllerTest
    {
        [TestMethod]
        public void TestIndexViewWithNoLogin()
        {
            // AAA
            //Arrange
            var controller = new AccountsController();
            controller.Username = null;
            //Act & Assert
            Assert.ThrowsException<NullReferenceException>(controller.Index);
        }

        [TestMethod]
        public void TestIndexViewWithLogin()
        {
            var controller = new AccountsController();
            controller.Username = "test@test.com";

            var result = controller.Index() as ViewResult;
            var data = (result.Model) as IEnumerable<Account>;
            var count = 0;
            foreach (var item in data)
            {
                count++;
            }
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void TestIndexViewWithEmptyLogin()
        {
            var controller = new AccountsController();
            controller.Username = "";

            Assert.ThrowsException<ArgumentNullException>(controller.Index);
        }

    }
}
