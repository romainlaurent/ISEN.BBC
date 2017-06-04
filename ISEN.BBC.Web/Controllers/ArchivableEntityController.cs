using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISEN.BBC.Library.Models;
using ISEN.BBC.Library.Repositories.Implementation;
using ISEN.BBC.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ISEN.BBC.Web.Controllers
{
    public abstract class ArchivableEntityController<IRepo, T> : BaseController<IRepo, T>
        where IRepo : IArchivableEntityRepository<T>
        where T : ArchivableEntity
    {
        public ArchivableEntityController(
            IRepo archivableEntityRepository,
            ILogger<ArchivableEntityController<IRepo, T>> logger) : base(archivableEntityRepository, logger)
        {            
        }

        [HttpGet]
        public JsonResult AllArchived()
        {
            var model = Repository.GetAll(true);
            return Json(model);
        }

        public IActionResult IndexArchived()
        {
            var model = Repository.GetAll(true);
            return View(model);
        }
    }
}
