using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BLL.Api
{
    public class BaseSqlSugar<T> where T : class, new()
    {
        private SqlSugarClient _client;
        public virtual SqlSugarClient db
        {
            get
            {
                if (_client == null)
                {
                    _client = SqlSugarHelper.GetInstance();
                }
                return _client;
            }
        }

        public virtual T GetModel(int id)
        {
            var model = db.Queryable<T>().Where($"Id={id}").Single();
            return model;
        }

        public virtual T GetModel(string where)
        {
            var model = db.Queryable<T>().Where(where).Single();
            return model;
        }

        public virtual T GetModel(string where, object pars = null)
        {
            var model = db.Queryable<T>().Where(where, pars).Single();
            return model;
        }

        public virtual List<T> GetList(string where, object pars = null)
        {
            var list = db.Queryable<T>().Where(where, pars).ToList();
            return list;
        }

        public virtual List<T> GetList(string where, int pageIndex = 1, int pageSize = 10, object pars = null)
        {
            var list = db.Queryable<T>().Where(where, pars).ToPageList(pageIndex, pageSize);
            return list;
        }

        public virtual bool Update(T account)
        {
            var result = db.Updateable(account).ExecuteCommand();
            return result > 0;
        }

        public virtual bool Update(T account, string[] columns)
        {
            var result = db.Updateable(account).UpdateColumns(columns).ExecuteCommand();
            return result > 0;
        }

        public virtual bool UpdateIgnore(T account, string[] columns)
        {
            var result = db.Updateable(account).IgnoreColumns(columns).ExecuteCommand();
            return result > 0;
        }

        public virtual bool Update(List<T> accounts)
        {
            var result = db.Updateable(accounts).ExecuteCommand();
            return result > 0;
        }

        public virtual int Insert(T account)
        {
            var id = db.Insertable(account).ExecuteReturnIdentity();
            return id;
        }

        public virtual int Insert(T account, string[] columns)
        {
            var id = db.Insertable<T>(account).InsertColumns(columns).ExecuteReturnIdentity();
            return id;
        }

        public virtual int InsertIgnore(T account, string[] columns)
        {
            var id = db.Insertable(account).IgnoreColumns(columns).ExecuteReturnIdentity();
            return id;
        }

        public virtual bool Insert(T account, out int count)
        {
            count = db.Insertable(account).ExecuteCommand();
            return count > 0;
        }

        public virtual int InsertList(List<T> accounts)
        {
            if (accounts != null && accounts.Count > 0)
            {
                foreach (var item in accounts)
                {
                    db.Insertable(item).AddQueue();
                }
                var result = db.SaveQueues();
                return result;
            }
            return 0;
        }

        public virtual bool Delete(int id)
        {
            var result = db.Deleteable<T>().In(id).ExecuteCommand();
            return result > 0;
        }

        public virtual bool Delete(int[] ids)
        {
            var result = db.Deleteable<T>().In(ids).ExecuteCommand();
            return result > 0;
        }

        public virtual bool Delete(string where)
        {
            var result = db.Deleteable<T>().Where(where).ExecuteCommand();
            return result > 0;
        }

    }
}
