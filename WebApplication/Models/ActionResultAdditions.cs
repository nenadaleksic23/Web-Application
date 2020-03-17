using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class ActionResultAdditions
    {
        public class JsonSuccess : ActionResult
        {
            public override void ExecuteResult(ControllerContext context)
            {
                throw new NotImplementedException();
            }
        }
    }
}