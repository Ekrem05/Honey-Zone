using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using HoneyZoneMvc.Infrastructure.ViewModels.Status;
using Microsoft.EntityFrameworkCore;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class StatusService : IStatusService
    {
        private ApplicationDbContext dbContext;

        public StatusService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<IEnumerable<StatusViewModel>> GetAllAsync()
        {
            return dbContext.States
                 .AsNoTracking()
                 .Select(s => new StatusViewModel()
                 {
                     Id = s.Id.ToString(),
                     Name = s.Name
                 }).ToList();

        }

        public async Task<State> GetInitialOrderStatus()
        {
            return dbContext.States.FirstOrDefault(s => s.Name == "В обработка");
        }
    }
}
