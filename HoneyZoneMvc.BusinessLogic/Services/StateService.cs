using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class StateService : IStateService
    {
        private ApplicationDbContext dbContext;

        public StateService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<State> GetInitialOrderState()
        {
            return dbContext.States.FirstOrDefault(s => s.Name == "В обработка");
        }
    }
}
