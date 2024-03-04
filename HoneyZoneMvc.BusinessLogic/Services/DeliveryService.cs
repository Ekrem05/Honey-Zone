using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.ViewModels.Delivery;
using Microsoft.EntityFrameworkCore;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class DeliveryService : IDeliveryService
    {
        private ApplicationDbContext dbContext;

        public DeliveryService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Task<bool> AddAsync(DeliveryMethodViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<DeliveryMethodViewModel>> GetAllAsync()
        {
            var items = await dbContext.DeliverMethods.ToListAsync();
            return items.Select(d => new DeliveryMethodViewModel()
            {
                Id = d.Id.ToString(),
                Name = d.Name
            }).ToList();

        }

        public Task<bool> UpdateAsync(DeliveryMethodViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
