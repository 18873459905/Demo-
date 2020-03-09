using LT.DAL;
using LT.IBLL;
using LT.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LT.Model;
using System.Data.Entity;

namespace LT.BLL
{
    //逻辑层帮助类
    public class BaseBLL<T> : IBaseBLL<T> where T : class
    {
        internal LTDBContent _db;
        internal DbSet<T> _dbset;


        public IBaseDal<T> CurrentDal { get { return new BaseDal<T>(); } }

        //public IDBSession dBSession { get { return new DBSession(); } }
        public BaseBLL(LTDBContent dbcontent){
            _db = dbcontent;
            this._dbset = this._db.Set<T>();
        }


        public bool DeleteEntity(T entity)
        {
            CurrentDal.DeleteEntity(entity);
            return CurrentDal.SaveChanges();
        }

        public bool EditEntity(T entity)
        {
            CurrentDal.EditEntity(entity);
            return CurrentDal.SaveChanges(); 
        }

        public T GetEntityById(object id)
        {
            return CurrentDal.GetEntityById(id);
        }

        public T GetEntityFirst(System.Linq.Expressions.Expression<Func<T, bool>> where = null)
        {
            return CurrentDal.GetEntityFirst();
        }

        public List<T> InserEntity(List<T> entities)
        {
            CurrentDal.InserEntity(entities);
            CurrentDal.SaveChanges();
            return entities;
        }
        //使用dBSession的SaveChanges();
        public T InsertSection(T model)
        {
            CurrentDal.InsertSection(model);
            //_db.SaveChanges();
            CurrentDal.SaveChanges();
            return model;
        }

        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLamda)
        {
            return CurrentDal.LoadEntities(whereLamda);
        }

        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLamda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            return CurrentDal.LoadPageEntities<s>(pageIndex, pageSize, out totalCount,
                whereLamda, orderbyLambda, isAsc);
        
        }

                public IEnumerable<T> GetEntityList(System.Linq.Expressions.Expression<Func<T, bool>> where = null, 
          Func<IQueryable<T>,IOrderedQueryable<T>> order = null, string includeProperties = "")
        {
            IQueryable<T> query = this._dbset;
            if (where != null)
            {
                query = query.Where(where);
            }
            if (order!=null) {
                query = order(query);
            }
            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public bool SaveChanges()
        {
            return CurrentDal.SaveChanges();
        }
    }
}
