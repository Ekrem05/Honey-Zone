using HoneyZoneMvc.Contracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Contracts
{
    public interface ICartProductService
    {
       
        Task<bool> AddCartProductAsync(CartProductDto dto);
        Task<bool> UpdateQuantityAsync(string productId, int quantity, string userId);

    }
}
