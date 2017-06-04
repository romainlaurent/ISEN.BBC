using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ISEN.BBC.Library.Models;
using ISEN.BBC.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ISEN.BBC.Web.Controllers
{
    public class ReservationController : BaseController<IReservationRepository, Reservation>
    {
        private readonly IVoyageRepository _voyageRepository;

        public ReservationController(IVoyageRepository voyageRepository,
            IReservationRepository reservationRepository,
            ILogger<ReservationController> logger) : base(reservationRepository, logger)
        {
            _voyageRepository = voyageRepository;
        }

        public override IActionResult Detail(Reservation entity)
        {
            //L'id de l'objet sort invalide, a corriger
            if (ModelState.ErrorCount > 1)
            {
                return View();
            }
            Repository.Update(entity);
            Repository.Save();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DetailWithVoyageId(int id)
        {
            ViewData["VoyageId"] = id;

            var reservation = Repository.Single(e => e.VoyageId == id);

            var voyage = _voyageRepository.Single(id);

            ViewBag.CurrentDepart = voyage.Depart;
            ViewBag.CurrentDestination = voyage.Destination;
            ViewBag.CurrentDate = voyage.Date.ToString();

            return View("Detail");
        }
    }
}