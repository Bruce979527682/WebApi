using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BLL.Api
{
    public class SqlSugarHelper
    {
        //https://github.com/sunkaixuan/SqlSugar
        /// <summary>
        /// Create SqlSugarClient
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConfigHelper.GetConnectionValue("Default"),
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            //Print sql
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;
        }
    }
}
