using GoHunter.Business.Models;
using System;
using System.Threading.Tasks;

namespace GoHunter.Business.Interfaces
{
    public interface ICompanyRepository: IRepository<Company>
    {
        Task<Company> GetCompanyAddress(Guid id);
        Task<Company> GetCompanyJobOffersAddress(Guid id);

    }
}
