using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyZoneMvc.BusinessLogic.Services
{
    public class StateService:IStateService
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
