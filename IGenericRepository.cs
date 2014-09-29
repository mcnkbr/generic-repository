using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository
{
    public interface IGenericRepository<TM, TD>
        where TM : class
        where TD : class
    {
        List<TD> GetAll(bool mapReset = true);
        List<TD> FindBy(Expression<Func<TM, bool>> predicate, bool mapReset = true);
        void Add(TD entity);
        void Add(TM entity);
        int Add(TD entity, bool returnId, string returnName);
        void Delete(Expression<Func<TM, bool>> predicate);
        void Edit(TD entity, bool hasMap = false);
        void Save();
    }
}