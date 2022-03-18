using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSystemDemo.MyFilter
{
    public class CustomExceptionFilter : FilterAttribute,
IExceptionFilter
    {
       
        public void OnException(ExceptionContext filterContext)
        {
            Debug.WriteLine("Error");
            if (!filterContext.ExceptionHandled && filterContext.Exception is NullReferenceException)
            {
                filterContext.Result = new RedirectResult("/Home/Error");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}