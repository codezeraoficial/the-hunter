using GoHunter.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoHunter.Business.Interfaces
{
    public interface ISkillRepository : IRepository<Skill>
    {
        Task<IEnumerable<Skill>> GetSkillsByEmployee(Guid employeeId);
        Task<IEnumerable<Skill>> GetSkillsByJobOffer(Guid jobOfferId);
        Task<IEnumerable<Skill>> GetSkillsEmployees();
        Task<IEnumerable<Skill>> GetSkillsJobOffers();
        Task<Skill> GetSkillEmployee(Guid id);
        Task<Skill> GetSkillJoboffer(Guid id);
    }
}
