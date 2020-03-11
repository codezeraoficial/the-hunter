using AutoMapper;
using Domain.Models;
using Service.ViewModels;

namespace Api.AutoMapper
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Company, CompanyViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<JobOffer, JobOfferViewModel>().ReverseMap();
            CreateMap<Occupation, OccupationViewModel>().ReverseMap();
            CreateMap<Skill, SkillViewModel>().ReverseMap();
            CreateMap<Tech, TechViewModel>().ReverseMap();
        }
    }
}
