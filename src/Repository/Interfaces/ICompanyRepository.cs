using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICompanyRepository: IRepository<Company>
    {
        Task<Company> GetCompanyAddress(Guid id);
        Task<Company> GetCompanyJobOffersAddress(Guid id);

    }
}
