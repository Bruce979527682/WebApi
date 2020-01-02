using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interface
{
    public interface IUserRepository
    {
        Task WriteMessage(string message);
    }
}
