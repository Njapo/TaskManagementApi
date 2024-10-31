using TaskManagementApi.Models;

namespace TaskManagementApi.Repository.IRepository
{
    public interface IProjectTaskRepository : IRepository<ProjectTask>
    {
        Task<ProjectTask> Update(ProjectTask task);
    }
}
