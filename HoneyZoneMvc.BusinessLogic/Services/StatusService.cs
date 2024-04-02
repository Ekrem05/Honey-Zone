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

        public async Task<IEnumerable<StatusViewModel>> AllAsync()
        {
            return await (dbContext.Statuses
                 .AsNoTracking()
                 .Select(s => new StatusViewModel()
                 {
                     Id = s.Id.ToString(),
                     Name = s.Name
                 }).ToListAsync());
        }

        public async Task<StatusViewModel> GetByIdAsync(string Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException();
            }
            var status=await dbContext.Statuses.FindAsync(Guid.Parse(Id));
            if (status==null)
            {
                throw new ArgumentNullException();
            }
           return new StatusViewModel()
                  {
                    Id = status.Id.ToString(),
                    Name = status.Name
                  };
        }

        public async Task<Status> GetInitialOrderStatus()
        {
            return await dbContext.Statuses.FirstOrDefaultAsync(s => s.Name == DataConstants.Satus.InitialStatus);
        }
    }
}
