using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCSystemDemo.MyFilter
{
    public interface IExceptionFilter
    {
        void OnException(ExceptionContext filterContext);
    }
}
