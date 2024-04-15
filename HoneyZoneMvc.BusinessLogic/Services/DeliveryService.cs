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
        public async Task<DeliveryMethodViewModel> GetByIdAsync(string Id)
        {
            if (Id==null)
            {
                throw new ArgumentNullException();
            }
            var model= await dbContext.DeliverMethods.FindAsync(Guid.Parse(Id));
            if (model==null)
            {
                throw new InvalidOperationException();
            }
            return new DeliveryMethodViewModel()
            {
                Id = model.Id.ToString(),
                Name = model.Name
            };
        }
    }
}
