using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore.Infrastructure
{
    public class DbContextTransactionFilter : IAsyncActionFilter
    {
        private readonly ParadeContext _dbContext;

        public DbContextTransactionFilter(ParadeContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                _dbContext.BeginTransaction();
                await next();
                await _dbContext.CommitTransactionAsync();
            }
            catch (Exception)
            {
                _dbContext.RollbackTransaction();
                throw;
            }
        }
    }
}
