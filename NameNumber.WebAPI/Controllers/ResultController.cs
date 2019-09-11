using NameNumber.Business.Implementation;
using NameNumber.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace NameNumber.WebAPI.Controllers
{
    public class ResultController :ApiController
    {     
        public IHttpActionResult Get()
        {           
            return Ok("ok");
        }
        
        [HttpPost]
        public async Task<IHttpActionResult> Post(InputModel model)
        {
            NameNumberDA DAobj = new NameNumberDA();
            //The conditional code can be made as common code in filter
            //This approach is used so that we can return a common format when any error occurs.
            if (model == null)
            {
                return BadRequest(getModelDictionary(new List<string>() { "Input Parameters Not Found" }));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await DAobj.GetNameAndNumberInWords(model.Name, model.Number);
            if (result.IsSuccessStatus)
                return Ok(result);
            else
                return BadRequest(getModelDictionary(result.ErrorMessages));
        }

        protected ModelStateDictionary getModelDictionary(List<string> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in errors)
                modelStateDictionary.AddModelError("ValidationError", error);
            return modelStateDictionary;
        }
    }
}
