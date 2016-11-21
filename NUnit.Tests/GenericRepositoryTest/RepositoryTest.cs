using NUnit.Framework;
using NUnit.Tests.GenericRepositoryTest;
using SNOW_Solution.Controllers;
using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NUnit.Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }

        [Test]
        public void TestRepository()
        {
         //   var repository = new TestGenericRepository<Product>();
          //  ProductController controller = new ProductController(repository);
       //     var result = (ViewResult)controller.Index();
       //     List<Product> data = (List<Product>)result.ViewData.Model;
       //     Assert.IsFalse(data.Count <= 0);
        }
    }
}
