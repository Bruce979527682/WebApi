using Data.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace BLL.Api
{
    public class AccountBLL
    {
        public ApiContext _context;
        public AccountBLL(ApiContext context)
        {
            _context = context;
        }
    }
}
