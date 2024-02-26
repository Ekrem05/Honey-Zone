using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class DeliveryService : IDeliveryService
    {
        private ApplicationDbContext dbContext;

        public DeliveryService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Task<bool> AddAsync(DeliveryMethodDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<DeliveryMethodDto>> GetAllAsync()
        {
            var items = await dbContext.DeliverMethods.ToListAsync();
            return items.Select(d => new DeliveryMethodDto()
            {
                Id = d.Id.ToString(),
                Name = d.Name
            }).ToList();
            
        }

        public Task<bool> UpdateAsync(DeliveryMethodDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
