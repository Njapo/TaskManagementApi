using AutoMapper;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using TaskManagementApi.Models;
using TaskManagementApi.Models.DTO;

namespace TaskManagementApi
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ProjectTask, ProjectTaskDTO>()
                .ForMember(dest => dest.DaysBetween, opt =>
                    opt.MapFrom(src => (src.EndDate - src.StartDate).Days))
                .ForMember(dest => dest.ProgressPercentage, opt =>
                    opt.MapFrom(src => CalculateProgressPersentage(src)))
                .ForMember(dest=>dest.Warning,opt=>
                    opt.MapFrom(src=>src.EndDate<src.StartDate));

            CreateMap<ProjectTask,ProjectTaskCreateDTO>().ReverseMap();
            CreateMap<ProjectTask, ProjectTaskUpdateDTO>().ReverseMap();
            CreateMap<LocalUser,RegistrationRequestDTO>().ReverseMap();
        }

        private double CalculateProgressPersentage(ProjectTask dto)
        {
            if (dto.Description.IsNullOrEmpty())
            {
                return 0;
            }
            int totalSymbolsInDescription = dto.Description.Length;
            int onlyLettersAndDigits = 0;
            for(int i=0; i<dto.Description.Length; i++)
            {
                char current = dto.Description[i];
                if((current>=49 && current<=57) ||  (current>=65 && current<=90) || (current>=97 && current <= 122))
                {
                    onlyLettersAndDigits++;
                }
            }
            double result = (double)onlyLettersAndDigits / totalSymbolsInDescription;
            return result;
        }
    }
}
