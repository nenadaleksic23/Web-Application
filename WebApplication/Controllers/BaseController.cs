using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult JsonSuccess(string CallBack)
        {
            object obj = new { Status = "Ok", CallBack = CallBack };
            string res = JsonConvert.SerializeObject(obj);
            return Content(res, "application/json");

        }
        public ActionResult JsonError(string message)
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = 400;
            return Json(new { Status = "error", Message = message });                
        }
    }
}