using LT.DAL;
using LT.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LT.IBLL
{
    public interface IBaseBLL<T> where T : class
    {
        //IDBSession CurentDBSession { get; }
        //IBaseDal<T> CurrentDal { get; set; }

        /// <summary>
        /// 查询该实体全部内容
        /// </summary>
        /// <param name="whereLamda"></param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLamda);

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageSize">共多少页</param>
        /// <param name="totalCount">总页数</param>
        /// <param name="whereLamda">条件Lamda</param>
        /// <param name="orderbyLambda">排序Lamda</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount,
            System.Linq.Expressions.Expression<Func<T, bool>> whereLamda,
            System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteEntity(T entity);
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool EditEntity(T entity);
        /// <summary>
        /// 添加多条实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        List<T> InserEntity(List<T> entities);
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        T InsertSection(T model);
        /// <summary>
        /// 根据id找数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetEntityById(object id);
        /// <summary>
        /// 返回第一个
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        T GetEntityFirst(System.Linq.Expressions.Expression<Func<T, bool>> where = null);

        IEnumerable<T> GetEntityList(System.Linq.Expressions.Expression<Func<T, bool>> where = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> order = null, string includeProperties = "");

        bool SaveChanges();
    }
}
