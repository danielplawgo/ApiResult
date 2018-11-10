using ApiResult.Infrastructure;
using ApiResult.Models;
using ApiResult.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiResult.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult GetById(int id)
        {
            var user = new User()//oczywiście pomijam tutaj kod związany z pobieraniem danych
            {
                Id = id
            };

            return SuccessResult(user);
        }

        public ActionResult Add(User user)//tutaj oczywiście powinno skorzystać się z viewmodelu - w jednym z maili to opisywałem
        {
            var validator = new UserValidator();

            var validationResult = validator.Validate(user);

            if(validationResult.IsValid == false)
            {
                return ErrorResult(validationResult.Errors);
            }

            //dodanie do bazy itd.

            return SuccessResult(user);
        }
    }
}