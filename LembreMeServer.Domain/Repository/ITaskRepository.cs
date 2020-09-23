using System.Collections.Generic;
using System.Threading.Tasks;
using TaskDomain = LembreMeServer.Domain.Entities.Task;

namespace LembreMeServer.Domain.Repository
{
    public interface ITaskRepository : IRepository<TaskDomain>
    {
        Task<IEnumerable<TaskDomain>> GetAllCompletedTasksAsync();
    }
}
