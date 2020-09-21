using LembreMeServer.Domain.Entities;
using LembreMeServer.Domain.Repository;
using LembreMeServer.Infra.Context;

namespace LembreMeServer.Infra.Repository
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(IAppContext appContext) : base(appContext)
        {

        }
    }
}
