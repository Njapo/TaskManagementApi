namespace TaskManagementApi.Models.DTO
{
    public interface IProjectTaskDTO
    {
        string Name { get; set; }
        string Description { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
