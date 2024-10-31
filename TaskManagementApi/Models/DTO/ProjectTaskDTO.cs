
namespace TaskManagementApi.Models.DTO
{
    public class ProjectTaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }
        public int DaysBetween { get; set; }
        public double ProgressPercentage { get; set; }
        public string Warning { get; set; }
    }
}
