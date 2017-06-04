using System;
using System.Linq.Expressions;
using ISEN.BBC.Library.Models;
using ISEN.BBC.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ISEN.BBC.Web.Controllers
{
    public abstract class BaseController<IRepo, T> : Controller
        where IRepo : IBaseRepository<T>
        where T : BaseEntity
    {
        protected readonly ILogger<BaseController<IRepo, T>> Logger;
        protected readonly IRepo Repository;

        public BaseController(
            IRepo repository,
            ILogger<BaseController<IRepo, T>> logger)
        {
            Repository = repository;
            Logger = logger;
        }

        [HttpGet]
        public virtual JsonResult All()
        {
            var model = Repository.GetAll();
            return Json(model);
        }

        public virtual IActionResult Index()
        {
            var model = Repository.GetAll();
            return View(model);
        }

        public virtual IActionResult Detail(int? id)
        {
            if (id == null) return View();
            var model = Repository.Single(id.Value);
            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Detail(T entity)
        {
            //L'id de l'objet sort invalide, a corriger
            if (ModelState.ErrorCount > 1)
            {
                return View();
            }
            Repository.Update(entity);
            Repository.Save();
            return RedirectToAction("Index");
        }

        public virtual IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Repository.Delete(id.Value);
                Repository.Save();
            }
            return RedirectToAction("Index");
        }

        protected Expression<Func<T, bool>> Concat(
            Expression<Func<T, bool>> expr1, 
            Expression<Func<T, bool>> expr2)
        {
            ParameterExpression param = expr1.Parameters[0];
            if (ReferenceEquals(param, expr2.Parameters[0]))
            {
                return Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(expr1.Body, expr2.Body), param);
            }
            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    expr1.Body,
                    Expression.Invoke(expr2, param)), param);
        }
    }
}