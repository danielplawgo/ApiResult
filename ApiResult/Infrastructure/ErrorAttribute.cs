using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiResult.Infrastructure
{
    public class ErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;

            //zapis samego wyjątku do logu - np. z wykorzystaniem nloga

            filterContext.ExceptionHandled = true;

            var result = new ViewModels.ApiResult() {
                Success = false,
                Errors = new List<ViewModels.ApiResultErrorMessage>()
                {
                    new ViewModels.ApiResultErrorMessage()
                    {
                        PropertyName = string.Empty,
                        Error = ex.Message
                    }
                }
            };

            filterContext.Result = new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = result
            };
        }
    }
}