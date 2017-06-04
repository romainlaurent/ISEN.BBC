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
    public class VoyageRepository : ArchivableEntityRepository<Voyage>, IVoyageRepository
    {
        public VoyageRepository(ApplicationDbContext context,
            ILogger<VoyageRepository> logger) : base(context, logger)
        {
            Logger.LogWarning("VoyageRepository was newed");
        }

        public override IQueryable<Voyage> EntityCollection
            => Context.VoyageCollection.AsQueryable();

        public override IQueryable<Voyage> Includes(IQueryable<Voyage> queryable)
        {
            queryable = base.Includes(queryable);
            queryable = queryable.Include(e => e.ReservationCollection);
            return queryable;
        }
    }
}