using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ISEN.BBC.Library.Models;

namespace ISEN.BBC.Library.Repositories.Interfaces
{
    public interface IArchivableEntityRepository<T> : IBaseRepository<T>
        where T : ArchivableEntity
    {
        void Archive(int id);
        void Restore(int id);
        //p = true => GetAll archived ; p = false => GetAll not Archived
        IEnumerable<T> GetAll(bool p);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate, bool p);
    }
}
