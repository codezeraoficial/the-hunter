using GoHunter.Business.Models;
using GoHunter.Business.Models.Validations;
using GoHunter.Business.Interfaces;
using System;
using System.Threading.Tasks;

namespace GoHunter.Business.Services
{
    public class CompanyrService : BaseService, ICompanyService
    {
        public async Task Add(Company company)
        {
            if (!ExecutarValidacao(new CompanyValidation(), company)
               && !ExecutarValidacao(new AddressValidation(), company.Address)) return;
        }

        public async Task Update(Company company)
        {
            if (!ExecutarValidacao(new CompanyValidation(), company)) return;
        }

        public async Task UpdateAddress(Address address)
        {
            if (!ExecutarValidacao(new AddressValidation(), address)) return;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
