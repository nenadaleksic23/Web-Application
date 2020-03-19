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
            Exception = ex;
        }
        public Exception Exception { get; set; }
        public object ResponseObject { get; set; }
        public bool IsSuccess
        {
            get
            {
                return Exception == null;
            }
        }
        public string Error
        {
            
            get
            {
                string err = string.Empty;
                if (Exception != null)
                {
                    err = Exception.Message;
                }
                return err;
            }
        }

    }
}