using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetIdentity.WebClientAdmin.Models
{
    public class GeneralResponse
    {
        public string Message { get; set; }
        public bool Successfully { get; set; }
        public string Data { get; set; }
    }
}