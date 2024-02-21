using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Contracts.SubContracts
{
    public interface ICrud<T>
    {
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task<bool> UpdateAsync(T entity);
    }
}
