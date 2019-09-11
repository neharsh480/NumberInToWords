using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NameNumber.WebAPI.Common.Models
{
    public class Response
    {
        public Response()
        {
            ErrorMessages = new List<string>();
        }
        public bool IsSuccessStatus { get; set; }
        public List<string> ErrorMessages { get; set; }
        public dynamic Data { get; set; }
    }
}