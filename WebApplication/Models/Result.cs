using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Result
    {
        public Result()
        { 
        }
        public Result(Exception ex)
        {
            this.Exception = ex;
        }
        public Exception Exception { get; set; }
        public object ResponseObject { get; set; }
        public bool IsSuccess
        {
            get
            {
                return this.Exception != null;
            }
        }
        public string Error
        {
            
            get
            {
                string err = string.Empty;
                if (Exception != null)
                {
                    err = Exception.InnerException.Message;
                }
                return err;
            }
        }

    }
}