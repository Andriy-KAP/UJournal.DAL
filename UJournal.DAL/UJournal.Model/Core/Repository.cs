using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UJournal.Model.Behavior;

namespace UJournal.Model.Core
{
    internal class Repository<T> : IRepository<T> where T : class, IEntity,
    {
        private UJournalContext _context;
        private DbSet<T> _set;
        public Repository(UJournalContext _context)
        {
            this._context = _context;
            this._set = _context.Set<T>();
        }
        public IQueryable<T> Get()
        {
            return this._context.Set<T>().AsQueryable<T>();
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return this._set.AsQueryable<T>().
                Where(expression);
        }
        public async Task<T> GetById(int id)
        {
            return await this._set.Where(_ => _.Id == id).FirstOrDefaultAsync();
        }

        public async Task Insert(T entity)
        {
            this._set.Add(entity);
            await this._context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            T target = await this._set.FindAsync(id);
            if(target != null)
            {
                this._set.Remove(target);
                await this._context.SaveChangesAsync();
            }
            else
            {
                throw new NullReferenceException("Record which you want to remove doesnt exist.");
            }
        }

        public async Task Update(T entity)
        {
            this._set.Update(entity);
            await this._context.SaveChangesAsync();
        }
    }
}
