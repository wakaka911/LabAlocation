using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LA.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace LA.DAO
{
    public class Repository<T> : IRepository<T> where T : PersistenceEntity
    {
        private ISession _session;
        protected virtual ISession Session
        {

            get
            {
                if (_session == null)
                {
                    return NHHelper.GetCurrentSession();
                }
                else
                {
                    return _session;
                }
            }
        }

        public Repository()
        { }

        public Repository(ISession session)
        {
            _session = session;
        }

        #region IRepository<T> 成员


        /// <summary>
        /// 延迟加载，返回的是一个代理对象，没有立即命中数据库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Load(string id)
        {
            try
            {
                return Session.Load<T>(id);
            }
            catch (Exception ex)
            {
                throw new Exception("获取实体失败", ex);
            }
        }
        /// <summary>
        /// 立即从数据库中加载该对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Get(string id)
        {
            try
            {
                return Session.Get<T>(id);
            }
            catch (Exception ex)
            {
                throw new Exception("获取实体失败", ex);
            }
        }

        public virtual T FindSingle(List<QueryField> queryList)
        {
            ICriteria crit = Session.CreateCriteria<T>();
            if (queryList != null)
            {
                foreach (var query in queryList)
                {
                    crit.Add(GetExpression(query));
                }
            }
            return crit.UniqueResult<T>();
        }

        public virtual IList<T> GetAll()
        {
            return Session.CreateCriteria<T>()
                .AddOrder(Order.Asc("CREATED"))
                .List<T>();
        }

        public virtual void Insert(T entity)
        {
            try
            {
                entity.CREATED = DateTime.Now;
                Session.Save(entity);
                Session.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception("插入实体失败", ex);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                entity.UPDATED = DateTime.Now;
                Session.Update(entity);
                Session.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception("更新实体失败", ex);
            }
        }

        public virtual void Delete(string id)
        {
            try
            {
                var entity = Get(id);
                Session.Delete(entity);
                Session.Flush();
            }
            catch (System.Exception ex)
            {
                throw new Exception("物理删除实体失败", ex);
            }
        }


        public virtual IList<T> GetList(int pageSize, int pageIndex, List<QueryField> queryList, SortField sort, out int recordCount)
        {
            int startIndex = pageSize * (pageIndex - 1);
            ICriteria crit = Session.CreateCriteria<T>();

            if (queryList != null)
            {
                foreach (var query in queryList)
                {
                    crit.Add(GetExpression(query));
                }
            }



            // Copy current ICriteria instance to the new one for getting the pagination records.
            ICriteria pageCrit = CriteriaTransformer.Clone(crit);

            // Get the total record count
            recordCount = Convert.ToInt32(pageCrit.SetProjection(Projections.RowCount()).UniqueResult());

            if (sort != null)
            {
                crit.AddOrder(GetOrder(sort));
            }

            return crit.SetFirstResult(startIndex)
                .SetMaxResults(pageSize)
                .List<T>();

        }
        public virtual IList<T> GetList(List<QueryField> queryList, SortField sort)
        {
            ICriteria crit = Session.CreateCriteria<T>();
            if (queryList != null)
            {
                foreach (var query in queryList)
                {
                    crit.Add(GetExpression(query));
                }
            }
            // Copy current ICriteria instance to the new one for getting the pagination records.
            ICriteria pageCrit = CriteriaTransformer.Clone(crit);
            if (sort != null)
            {
                crit.AddOrder(GetOrder(sort));
            }
            return crit.List<T>();
        }
        public Order GetOrder(SortField sort)
        {
            if (sort.Direction == SortDirection.Asc)
            {
                return Order.Asc(sort.Name).IgnoreCase();
            }
            else
            {
                return Order.Desc(sort.Name).IgnoreCase();
            }
        }
        public ICriterion GetExpression(QueryField query)
        {
            if (query.Type == QueryFieldType.String)
            {
                if (query.Comparison == QueryFieldComparison.like)
                    return Expression.Like(query.Name, query.Value.ToString(), MatchMode.Anywhere);
                else
                    return Expression.Eq(query.Name, query.Value.ToString());
            }
            if (query.Type == QueryFieldType.Boolean)
            {
                return Expression.Eq(query.Name, query.Value);
            }

            if (query.Type == QueryFieldType.Numeric || query.Type == QueryFieldType.DateTime)
            {

                switch (query.Comparison)
                {
                    case QueryFieldComparison.eq:
                        return Expression.Eq(query.Name, query.Value);
                    case QueryFieldComparison.ge:
                        return Expression.Ge(query.Name, query.Value);
                    case QueryFieldComparison.gt:
                        return Expression.Gt(query.Name, query.Value);
                    case QueryFieldComparison.le:
                        return Expression.Le(query.Name, query.Value);
                    case QueryFieldComparison.lt:
                        return Expression.Lt(query.Name, query.Value);
                    default:
                        return null;
                }
            }
            return null;
        }
        #endregion
    }
}
