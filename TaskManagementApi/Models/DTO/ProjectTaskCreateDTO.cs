﻿namespace TaskManagementApi.Models.DTO
{
    public class ProjectTaskCreateDTO : IProjectTaskDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }=false;
    }
}
