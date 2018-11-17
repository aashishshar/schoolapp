using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace WEB_APP_SCHOOL_NET.DAL
{
    public class Repository<TObject> : IRepository<TObject> where TObject : class
    {
        protected ModelContext Context;
        internal DbSet<TObject> dbSet;
        private bool shareContext = false;
        /// <summary>
        /// 
        /// </summary>
        public Repository()
        {
            Context = new ModelContext();
            this.dbSet = Context.Set<TObject>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public Repository(ModelContext context)
        {
            Context = context;
            shareContext = true;
        }

        protected DbSet<TObject> DbSet
        {
            get
            {
                return Context.Set<TObject>();
            }
        }

        public void Dispose()
        {
            if (shareContext && (Context != null))
                Context.Dispose();
        }

        public virtual IQueryable<TObject> All()
        {
            return DbSet.AsQueryable();
        }
        //public virtual IEnumerable<TObject> ExecWithStoreProcedure(string query, params object[] parameters)
        //public virtual DataTable ExecWithStoreProcedure(string query, SqlParameter[] parameters)
        //{
        //    try
        //    {
        //        StringBuilder strBuilder = new StringBuilder();
        //        strBuilder.Append($"EXECUTE {query}");
        //        strBuilder.Append(string.Join(",", parameters.ToList().Select(s => $" {s.ParameterName}")));
        //        return Context.Database.SqlQuery<DataTable>(strBuilder.ToString(), parameters).FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        //public IEnumerable<TObject> GetdataFromSqlcommand(string command, System.Data.SqlClient.SqlParameter[] parameter)
        //{
        //    StringBuilder strBuilder = new StringBuilder();
        //    strBuilder.Append($"EXECUTE {command}");
        //    strBuilder.Append(string.Join(",", parameter.ToList().Select(s => $" @{s.ParameterName}")));

        //    return Context.Set<TObject>().FromSql(strBuilder.ToString(), parameter);
        //}

        ////When you expect a model back (async)
        //public async Task<IList<T>> ExecWithStoreProcedureAsync<T>(string query, params object[] parameters)
        //{
        //    return await Context.Database.SqlQuery<T>(query, parameters).ToListAsync();
        //}

        ////When you expect a model back
        //public IEnumerable<T> ExecWithStoreProcedure<T>(string query)
        //{
        //    return Context.Database.SqlQuery<T>(query);
        //}

        //// Fire and forget (async)
        //public async Task ExecuteWithStoreProcedureAsync(string query, params object[] parameters)
        //{
        //    await Context.Database.ExecuteSqlCommandAsync(query, parameters);
        //}

        //// Fire and forget
        //public void ExecuteWithStoreProcedure(string query, params object[] parameters)
        //{
        //    Context.Database.ExecuteSqlCommand(query, parameters);
        //}


        public virtual IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<TObject>();
        }



        public virtual IEnumerable<TObject> Get(Expression<Func<TObject, bool>> filter = null, Func<IQueryable<TObject>, IOrderedQueryable<TObject>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TObject> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual IQueryable<TObject> Filter(Expression<Func<TObject, bool>> filter, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? DbSet.Where(filter).AsQueryable() :
                DbSet.AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) :
                _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public bool Contains(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public virtual TObject Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public virtual TObject Find(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual TObject Create(TObject TObject)
        {
            var newEntry = DbSet.Add(TObject);
            if (!shareContext)
                Context.SaveChanges();
            return newEntry;
        }

        public virtual int Count
        {
            get
            {
                return DbSet.Count();
            }
        }

        public virtual int Delete(TObject TObject)
        {
            DbSet.Remove(TObject);
            if (!shareContext)
                return Context.SaveChanges();
            return 0;
        }

        public virtual int Update(TObject TObject)
        {
           
            var entry = Context.Entry(TObject);
            DbSet.Attach(TObject);
            entry.State = EntityState.Modified;
            if (!shareContext)
                return Context.SaveChanges();
            return 0;
        }

        public virtual int Delete(Expression<Func<TObject, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            if (!shareContext)
                return Context.SaveChanges();
            return 0;
        }


        public IQueryable<TObject> Filter<Key>(Expression<Func<TObject, bool>> filter, out int total, int index = 0, int size = 50)
        {
            throw new NotImplementedException();
        }

        //void IRepository<TObject>.Delete(TObject t)
        //{
        //    throw new NotImplementedException();
        //}
        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            Context.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}


        //void IRepository<TObject>.Delete(TObject t)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
