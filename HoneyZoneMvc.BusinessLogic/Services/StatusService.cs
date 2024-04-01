using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.ViewModels.Status;
using HoneyZoneMvc.Constraints;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models;
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
            return await (dbContext.Statuses
                 .AsNoTracking()
                 .Select(s => new StatusViewModel()
                 {
                     Id = s.Id.ToString(),
                     Name = s.Name
                 }).ToListAsync());

        }

        public async Task<Status> GetInitialOrderStatus()
        {
            return dbContext.Statuses.FirstOrDefault(s => s.Name == DataConstants.Satus.InitialStatus);
        }
    }
}
