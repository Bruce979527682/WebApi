using Data.Api;
using Entity.Api;
using Microsoft.EntityFrameworkCore;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace BLL.Api
{
    public class AccountBLL : BaseSqlSugar<Account>
    {
        #region 单例
        private static AccountBLL _singleModel;
        private static readonly object SynObject = new object();

        private AccountBLL()
        {

        }

        public static AccountBLL SingleModel
        {
            get
            {
                if (_singleModel == null)
                {
                    lock (SynObject)
                    {
                        if (_singleModel == null)
                        {
                            _singleModel = new AccountBLL();
                        }
                    }
                }
                return _singleModel;
            }
        }
        #endregion

    }
}
