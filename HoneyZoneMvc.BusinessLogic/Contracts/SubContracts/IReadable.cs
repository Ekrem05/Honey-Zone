using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Contracts.SubContracts
{
    public interface IReadable<T> where T : class
    {
        Task<IEnumerable<T>> AllAsync();
        Task<T> GetByIdAsync(string Id);
    }
}