using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    //In real world that will be decider if method before succeded so i would know if to go forward or get callback
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