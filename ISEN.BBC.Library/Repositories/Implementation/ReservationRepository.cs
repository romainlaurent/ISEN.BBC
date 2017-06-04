using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISEN.BBC.Library.Data;
using ISEN.BBC.Library.Models;
using ISEN.BBC.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ISEN.BBC.Library.Repositories.Implementation
{
    public class ReservationRepository : BaseContextRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApplicationDbContext context,
            ILogger<ReservationRepository> logger) : base(logger, context)
        {
            Logger.LogWarning("ReservationRepository was newed");
        }

        public override IQueryable<Reservation> EntityCollection
            => Context.ReservationCollection.AsQueryable();

        public override IQueryable<Reservation> Includes(IQueryable<Reservation> queryable)
        {
            queryable = base.Includes(queryable);
            queryable = queryable.Include(e => e.Voyage);
            return base.Includes(queryable);
        }
    }
}