using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiResult.Infrastructure
{
    public class BaseController : Controller
    {
        protected ActionResult SuccessResult(object value = null)
        {
            var result = new ViewModels.ApiResult()
            {
                Success = true,
                Value = value
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected ActionResult ErrorResult(string message)
        {
            var result = new ViewModels.ApiResult()
            {
                Success = false,
                Errors = new List<ViewModels.ApiResultErrorMessage>()
                {
                    new ViewModels.ApiResultErrorMessage()
                    {
                        PropertyName = string.Empty,
                        Error = message
                    }
                }
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ErrorResult(IEnumerable<ValidationFailure> errors)
        {
            var result = new ViewModels.ApiResult()
            {
                Success = false,
                Errors = errors.Select(e => new ViewModels.ApiResultErrorMessage()
                {
                    PropertyName = e.PropertyName,
                    Error = e.ErrorMessage
                })
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }          
    }
}