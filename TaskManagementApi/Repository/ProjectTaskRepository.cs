using TaskManagementApi.Data;
using TaskManagementApi.Models;
using TaskManagementApi.Repository.IRepository;

namespace TaskManagementApi.Repository
{
    public class ProjectTaskRepository : Repository<ProjectTask>, IProjectTaskRepository
    {
        private readonly ApplicationDbContext _db;
        public ProjectTaskRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<ProjectTask> Update(ProjectTask task)
        {
            task.IsCompleted = true;
            task.EndDate= DateTime.Now;
            _db.ProjectTasks.Update(task);
            await _db.SaveChangesAsync();
            return task;
        }
    }
}
