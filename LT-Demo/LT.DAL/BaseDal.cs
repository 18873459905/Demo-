using LT.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LT.Model;
using System.Data.Entity;

namespace LT.DAL
{
    public class BaseDal<T> : IBaseDal<T> where T : class
    {
        DbContext Db = DBSessionFactory.CreateDbContext();
        public bool DeleteEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return true;
        }

        public bool EditEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return true;
        }

        public T GetEntityById(object id)
        {
            return Db.Set<T>().Find(id);
        }

        public T GetEntityFirst(Expression<Func<T, bool>> where = null)
        {
            if (where == null)
                return Db.Set<T>().FirstOrDefault();
            else
                return Db.Set<T>().FirstOrDefault(where);
        }

        /// <summary>
        /// 添加多条实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public List<T> InserEntity(List<T> entities)
        {
            Db.Set<T>().AddRange(entities);
            //Db.SaveChanges();
            return entities;
        }
        /// <summary>
        /// 添加单个实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public T InsertSection(T model)
        {
            Db.Set<T>().Add(model);
            return model;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLamda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLamda)
        {
            return Db.Set<T>().Where<T>(whereLamda);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">总页数</param>
        /// <param name="totalCount">总数</param>
        /// <param name="whereLamda">条件lambda</param>
        /// <param name="orderbyLambda">排序lambda</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLamda, Expression<Func<T, s>> orderbyLambda, bool isAsc)
        {
            var temp = Db.Set<T>().Where<T>(whereLamda); //获取users集合
            totalCount = temp.Count();
            if (isAsc)
            {
                temp = temp.OrderBy<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }

        public bool SaveChanges()
        {
            try
            {
                return Db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
