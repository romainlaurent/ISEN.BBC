using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ISEN.BBC.Library.Models;
using ISEN.BBC.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Remotion.Linq.Parsing.ExpressionVisitors;

namespace ISEN.BBC.Web.Controllers
{
    public class VoyageController : ArchivableEntityController<IVoyageRepository, Voyage>
    {
        public VoyageController(
            IVoyageRepository voyageRepository,
            ILogger<VoyageController> logger) : base(voyageRepository, logger)
        {
        }

        public override IActionResult Detail(Voyage entity)
        {
            //L'id de l'objet sort invalide, a corriger
            if (ModelState.ErrorCount > 1)
            {
                return View();
            }
            Repository.Update(entity);
            Repository.Save();
            return RedirectToAction("IndexAdministrateur", "Voyage");
        }

        public IActionResult IndexVoyageur()
        {
            var model = Repository.Find(v => v.Date >= DateTime.Now && !v.IsFull, false).OrderBy(v => v.Date);
            return View("index", model);
        }

        public IActionResult IndexAdministrateur()
        {
            var model = Repository.GetAll().OrderBy(v => v.Date);
            return View(model);
        }

        public override IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voyage = Repository.Single(id.Value);
            if (voyage == null)
            {
                return NotFound();
            }

            return View(voyage);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Repository.Delete(id);
            Repository.Save();
            return RedirectToAction("IndexAdministrateur");
        }

        public ViewResult FilterVoyage(string searchDepart, string searchDestination,
            string searchDateMin, string searchDateMax, bool? searchArchive)
        {
            ViewBag.CurrentDepart = searchDepart;
            ViewBag.CurrentDestination = searchDestination;
            ViewBag.CurrentDateMin = searchDateMin;
            ViewBag.CurrentDateMin = searchDateMax;

            Expression<Func<Voyage, bool>> expression1 = e => true;

            if (!string.IsNullOrEmpty(searchDepart))
                expression1 = Concat(expression1, e => e.Depart == searchDepart);

            if (!string.IsNullOrEmpty(searchDestination))
                expression1 = Concat(expression1, e => e.Destination == searchDestination);

            if (!string.IsNullOrEmpty(searchDateMin))
            {
                var dateMin = DateTime.Parse(searchDateMin);
                expression1 = Concat(expression1, e => e.Date > dateMin);
            }

            if (!string.IsNullOrEmpty(searchDateMax))
            {
                var dateMax = DateTime.Parse(searchDateMax);
                expression1 = Concat(expression1, e => e.Date < dateMax);
            }

            if (searchArchive != null)
            {
                    var voyages = Repository.Find(expression1, searchArchive.Value).OrderBy(v => v.Date);
                    return View("IndexAdministrateur", voyages);
            }

            if (string.IsNullOrEmpty(searchDestination))
                expression1 = Concat(expression1, e => e.Date >= DateTime.Now);

            expression1 = Concat(expression1, e => !e.IsFull);

            return View("Index", Repository.Find(expression1, false).OrderBy(v => v.Date));
        }
    }
}