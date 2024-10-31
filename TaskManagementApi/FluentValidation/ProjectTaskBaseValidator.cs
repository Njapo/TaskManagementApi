using FluentValidation;
using TaskManagementApi.Models.DTO;

namespace TaskManagementApi.FluentValidation
{
    public class ProjectTaskBaseValidator<T> : AbstractValidator<T> where T : IProjectTaskDTO
    {
        public ProjectTaskBaseValidator()
        {
            RuleFor(task => task.Name)
                .NotEmpty().WithMessage("Name is Required")
                .MaximumLength(100).WithMessage("Name must not exceed 100 character");
            RuleFor(task => task.Description)
                .MaximumLength(500).WithMessage("Description can not be more than 500 characters")
                .Must(DigitsAreMoreThan10).WithMessage("count of digits does not exceed 10");
            RuleFor(task => task.StartDate).LessThanOrEqualTo(task => task.EndDate);
        }
        private bool DigitsAreMoreThan10(string description)
        {
            int count = 0;
            foreach (char c in description)
            {
                if (c >= 48 && c <= 57)
                    count++;
            }
            return count <= 10;
        }
    }
}
