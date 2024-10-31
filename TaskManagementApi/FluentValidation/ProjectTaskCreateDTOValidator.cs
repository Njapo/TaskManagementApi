using FluentValidation;
using TaskManagementApi.Models.DTO;

namespace TaskManagementApi.FluentValidation
{
    public class ProjectTaskCreateDTOValidator : ProjectTaskBaseValidator<ProjectTaskCreateDTO>
    {
        public ProjectTaskCreateDTOValidator()
        {
            
        }
    }
}
