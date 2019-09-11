using NameNumber.Business.Implementation;
using NameNumber.WebAPI.Common.Models;
using NameNumber.WebAPI.Controllers;
using NameNumber.WebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Http.Results;

namespace NameNumber.WebAPI.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void SendNullData()
        {
            var controller = new ResultController();
            InputModel model = null;
            var result=controller.Post(model);
            var modelState = ((System.Web.Http.Results.InvalidModelStateResult)result.Result).ModelState;
            Assert.IsNotNull(modelState.Keys);
            Assert.IsTrue(modelState.ContainsKey("ValidationError"));
            Assert.IsTrue(modelState["ValidationError"].Errors.FirstOrDefault().ErrorMessage== "Input Parameters Not Found");           
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void SendActualValues()
        {
            var controller = new ResultController();
            InputModel model = new InputModel() {
                Name="test",
                Number=121.11m
            };
            var result = controller.Post(model).Result as OkNegotiatedContentResult<Response>;
            Assert.IsNotNull(result.Content);
            Assert.IsTrue(result.Content.Data== "test   One Hundred Twenty-One Dollars and Eleven Cents");
        }
    }
}
