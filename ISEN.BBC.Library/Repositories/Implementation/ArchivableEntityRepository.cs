using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ISEN.BBC.Library.Data;
using ISEN.BBC.Library.Models;
using ISEN.BBC.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ISEN.BBC.Library.Repositories.Implementation
{
    public abstract class ArchivableEntityRepository<T> : BaseContextRepository<T>, IArchivableEntityRepository<T>
        where T : ArchivableEntity
    {
        public ArchivableEntityRepository(ApplicationDbContext context,
            ILogger<ArchivableEntityRepository<T>> logger) : base(logger, context)
        {
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate, bool p)
        {
            if (p)
                return base.Find(predicate).Where(e => e.IsArchived);
            return base.Find(predicate).Where(e => !e.IsArchived);
        }

        public IEnumerable<T> GetAll(bool p)
        {
            if(p)
                return base.GetAll().Where(e => e.IsArchived);
            return base.GetAll().Where(e => !e.IsArchived);
        }

        public virtual void Archive(int id)
        {
            var queryable = EntityCollection.SingleOrDefault(e => e.Id == id);
            queryable.IsArchived = true;
        }

        public virtual void Restore(int id)
        {
            var queryable = EntityCollection.SingleOrDefault(e => e.Id == id);
            queryable.IsArchived = false;
        }
    }
}