using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonSamochodowy.Repository
{
    public class RepositoryBase<T> where T : class, IEntity
    {
        private ITransaction transaction;
        private ISession session;

        public RepositoryBase(ITransaction transaction, ISession session)
        {
            this.transaction = transaction;
            this.session = session;
        }

        public virtual int Add(T entity)
        {
            //using (ISession session = NHibernateSession.OpenSession())
            //using (ITransaction transaction = session.BeginTransaction())
            return (int)session.Save(entity);
            //transaction.Commit();

        }

        public virtual void Update(T entity)
        {
            session.Update(entity);
        }

        //public virtual void Delete(T entity)
        //{
        //    _dbSet.Remove(entity);
        //}

        //public virtual void Delete(int id)
        //{
        //    var itemToRemove = _dbSet.Find(id);
        //    _dbSet.Remove(itemToRemove);
        //}

        //public virtual void Delete(Expression<Func<T, bool>> where)
        //{
        //    IEnumerable<T> objects = _dbSet.Where(where).AsEnumerable();
        //    foreach (T obj in objects)
        //    {
        //        _dbSet.Remove(obj);
        //    }
        //}
        public virtual T GetById(int id)
        {
            //using (ISession session = NHibernateSession.OpenSession())
            {
                var persons = session.Query<T>().FirstOrDefault(k => k.Id == id);
                return persons;
            }

        }

        //public T Get(Expression<Func<T, bool>> where)
        //{
        //    return _dbSet.Where(where).FirstOrDefault();
        //}

        public IEnumerable<T> GetAll()
        {
            //using (ISession session = NHibernateSession.OpenSession())
            {
                var persons = session.Query<T>().ToList();
                return persons;
            }
        }

        //public IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        //{
        //    return _dbSet.Where(where).AsQueryable();
        //}














        //private readonly string EntityType;

        //public RepositoryBase()
        //{
        //    EntityType = typeof(T).ToString().Split('.').Last();
        //}

        //public virtual void Add(T entity)
        //{
        //    using (ISession session = NHibernateSession.OpenSession(EntityType))
        //    using (ITransaction transaction = session.BeginTransaction())
        //    {
        //        session.Save(entity);
        //        transaction.Commit();
        //    }
        //}

        ////public virtual void Update(T entity)
        ////{
        ////    _dbSet.Attach(entity);
        ////    _dataContext.Entry(entity).State = EntityState.Modified;
        ////}

        ////public virtual void Delete(T entity)
        ////{
        ////    _dbSet.Remove(entity);
        ////}

        ////public virtual void Delete(int id)
        ////{
        ////    var itemToRemove = _dbSet.Find(id);
        ////    _dbSet.Remove(itemToRemove);
        ////}

        ////public virtual void Delete(Expression<Func<T, bool>> where)
        ////{
        ////    IEnumerable<T> objects = _dbSet.Where(where).AsEnumerable();
        ////    foreach (T obj in objects)
        ////    {
        ////        _dbSet.Remove(obj);
        ////    }
        ////}

        //public virtual T GetById(int id)
        //{
        //    using (ISession session = NHibernateSession.OpenSession(EntityType))
        //    {
        //        var persons = session.Query<T>().FirstOrDefault(k => k.Id == id);
        //        return persons;
        //    }

        //}

        ////public T Get(Expression<Func<T, bool>> where)
        ////{
        ////    return _dbSet.Where(where).FirstOrDefault();
        ////}

        //public IEnumerable<T> GetAll()
        //{
        //    using (ISession session = NHibernateSession.OpenSession(EntityType))
        //    {
        //        var persons = session.Query<T>().ToList();
        //        return persons;
        //    }
        //}

        ////public IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        ////{
        ////    return _dbSet.Where(where).AsQueryable();
        ////}
    }
}