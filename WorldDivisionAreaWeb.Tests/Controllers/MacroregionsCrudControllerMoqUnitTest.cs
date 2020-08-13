using Common.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WorldDivisionAreaWeb.Controllers;
using WorldDivisionAreaWeb.Models;

namespace WorldDivisionAreaWeb.Tests.Controllers {

    [TestClass]
    public class MacroregionsCrudControllerMoqUnitTest {

        [TestMethod]
        //public void TestMethod1() {
        public void Index_Model_IsEntityObjectsCollection_moq() {
            var mock = new Mock<IRepository<Macroregion>>();
            var controller = new MacroregionsCrudController() {
                Repository = mock.Object
            };

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<Macroregion>));
        }

        [TestMethod]
        public void CreateGet_Model_IsEntityObject_moq() {
            var mock = new Mock<IRepository<Macroregion>>();
            var controller = new MacroregionsCrudController() {
                Repository = mock.Object
            };

            ViewResult result = controller.Create() as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(Macroregion));
        }

        [TestMethod]
        public void CreatePost_Result_RedirectToActionIndex_moq() {
            var mock = new Mock<IRepository<Macroregion>>();
            var controller = new MacroregionsCrudController() {
                Repository = mock.Object
            };
            Macroregion model = new Macroregion();

            ActionResult result = controller.Create(model);

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            var redirectResult = result as RedirectToRouteResult;
            Assert.AreEqual(redirectResult.RouteValues["action"], "Index");
        }

        [TestMethod]
        public void CreatePost_Repository_AddIsCalled_moq() {
            var mock = new Mock<IRepository<Macroregion>>();
            var controller = new MacroregionsCrudController() {
                Repository = mock.Object
            };
            Macroregion model = new Macroregion();

            ActionResult result = controller.Create(model);

            mock.Verify(e => e.Add(model));
        }

        [TestMethod]
        public void CreatePost_Repository_SaveIsCalled_moq() {
            var mock = new Mock<IRepository<Macroregion>>();
            var controller = new MacroregionsCrudController() {
                Repository = mock.Object
            };
            Macroregion model = new Macroregion();

            ActionResult result = controller.Create(model);

            mock.Verify(e => e.Save());
        }

        [TestMethod]
        public void CreatePost_TempData_KeysContains_message_moq() {
            var mock = new Mock<IRepository<Macroregion>>();
            var controller = new MacroregionsCrudController() {
                Repository = mock.Object
            };
            Macroregion model = new Macroregion();

            ActionResult result = controller.Create(model);

            Assert.IsTrue(controller.TempData.Keys.Contains("message"));
        }

        [TestMethod]
        public void CreatePost_ModelStateIsNotValid_ReturnedViewResult_moq() {
            var mock = new Mock<IRepository<Macroregion>>();
            var controller = new MacroregionsCrudController() {
                Repository = mock.Object
            };
            Macroregion model = new Macroregion();
            controller.ModelState.AddModelError("", "error message");

            ActionResult result = controller.Create(model);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = result as ViewResult;
            Assert.AreEqual(viewResult.Model, model);
        }

        [TestMethod]
        public void CreatePost_AddingError_ReturnedViewResult_moq() {
            var mock = new Mock<IRepository<Macroregion>>();
            var controller = new MacroregionsCrudController() {
                Repository = mock.Object
            };
            Macroregion model = new Macroregion();
            mock.Setup(m => m.Add(It.IsAny<Macroregion>())).Throws<Exception>();

            ActionResult result = controller.Create(model);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = result as ViewResult;
            Assert.AreEqual(viewResult.Model, model);
        }

        [TestMethod]
        public void CreatePost_AddingError_ModelStateIsNotValid_moq() {
            var mock = new Mock<IRepository<Macroregion>>();
            var controller = new MacroregionsCrudController() {
                Repository = mock.Object
            };
            Macroregion model = new Macroregion();
            mock.Setup(m => m.Add(It.IsAny<Macroregion>())).Throws<Exception>();
            Assert.IsFalse(controller.ModelState.Count > 0);

            ActionResult result = controller.Create(model);

            Assert.IsTrue(controller.ModelState.Count > 0);
            Assert.IsTrue(controller.ModelState.Keys.ElementAt(0) == "");
        }

        /*




        





        */



    }
}
