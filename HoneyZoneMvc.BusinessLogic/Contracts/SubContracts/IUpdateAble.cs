using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Contracts.SubContracts
{
    public interface IUpdateAble<T> where T : class
    {
        Task UpdateAsync(T model);
    }
}
