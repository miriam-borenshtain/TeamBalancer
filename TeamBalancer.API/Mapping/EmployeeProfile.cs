using AutoMapper;
using TeamBalancer.API.Models.Domain;
using TeamBalancer.API.Models.DTO;

namespace TeamBalancer.API.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<CreateEmployeeDto, Employee>().ReverseMap();
            CreateMap<UpdateEmployeeDto, Employee>().ReverseMap();
            CreateMap<Team, TeamDto>().ReverseMap();
        }
    }
}
