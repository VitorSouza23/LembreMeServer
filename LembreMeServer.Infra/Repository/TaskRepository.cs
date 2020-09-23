using LembreMeServer.Domain.Repository;
using LembreMeServer.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskDomain = LembreMeServer.Domain.Entities.Task;

namespace LembreMeServer.Infra.Repository
{
    public class TaskRepository : Repository<TaskDomain>, ITaskRepository
    {
        public TaskRepository(IAppContext appContext) : base(appContext)
        {

        }

        public async Task<IEnumerable<TaskDomain>> GetAllCompletedTasksAsync()
        {
            return await _appContext.Tasks.Where(t => t.Completed).ToListAsync();
        }
    }
}
