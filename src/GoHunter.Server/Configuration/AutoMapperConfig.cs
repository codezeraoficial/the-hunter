using AutoMapper;
using GoHunter.Business.Models;
using GoHunter.Server.ViewModels;

namespace GoHunter.Server.AutoMapper
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Company, CompanyViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<JobOffer, JobOfferViewModel>().ReverseMap();
            CreateMap<OccupationViewModel, OccupationViewModel>().ReverseMap();
            CreateMap<Skill, SkillViewModel>().ReverseMap();
            CreateMap<Tech, TechViewModel>().ReverseMap();     



        }
    }
}
