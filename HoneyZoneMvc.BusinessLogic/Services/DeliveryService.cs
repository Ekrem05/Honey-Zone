using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.Delivery;
using HoneyZoneMvc.Data;
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

        public async Task<IEnumerable<DeliveryMethodViewModel>> AllAsync()
        {
            var items = await dbContext.DeliverMethods.ToListAsync();
            var deliveries = items.Select(d => new DeliveryMethodViewModel()
            {
                Id = d.Id.ToString(),
                Name = d.Name
            }).ToList();
            if (deliveries == null)
            {
                throw new Exception();
            }
            return deliveries;

        }

        public Task<bool> UpdateAsync(DeliveryMethodViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryMethodViewModel> GetByIdAsync(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
