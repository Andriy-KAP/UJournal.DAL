using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UJournal.Model.Behavior
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> Get();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
        [return: MaybeNull]
        Task<T> GetById(int id);

        Task Insert(T entity);
        Task Update(T entity);

        Task Remove(int id);
    }
}
