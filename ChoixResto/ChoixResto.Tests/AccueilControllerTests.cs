using ChoixResto.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChoixResto.Tests
{
    class AccueilControllerTests
    {
        [TestMethod]
        public void AcceuilController_Index_RenvoiVueParDefaut()
        {
            AccueilController controller = new AccueilController();
            ViewResult resultat = (ViewResult)controller.Index();
            Assert.AreEqual(string.Empty, resultat.ViewName);
        }
        
    }
}
