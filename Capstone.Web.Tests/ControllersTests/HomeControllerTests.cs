using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void HomeController_IndexAction_ReturnIndexView()
        {
            //Arrange
            //HomeController controller = new HomeController(booksDAL);

            //Act
            //ViewResult result = controller.Index() as ViewResult;

            //Assert
           //Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod()]
        public void HomeController_PartialNewAuthorList_ReturnPartialViewNewAuthorListView()
        {
            
        }
    }
}