using GoHunter.Business.Models;
using GoHunter.Business.Models.Validations;
using GoHunter.Business.Interfaces;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace GoHunter.Business.Services
{
    public class CompanyService : BaseService, ICompanyService
    {

        private readonly ICompanyRepository _companyRepository;
        private readonly IAddressRepository _addressRepository;

        public CompanyService(ICompanyRepository companyRepository, IAddressRepository addressRepository, INotifier notifier) : base(notifier)
        {
            _companyRepository = companyRepository;
            _addressRepository = addressRepository;
        }

        public async Task<Company> Add(Company company)
        {
            company.Id = Guid.NewGuid();
            company.AddressId = Guid.NewGuid();
            company.Address.Id = company.AddressId;

            if (!ExecuteValidation(new CompanyValidation(), company)) return null;

            var companies = await _companyRepository.Get(c => c.Document == company.Document);
            if (companies.Any())
            {
                Notify("There is already a company with the document informed.");

                return null;
            }
            try
            {
                await _companyRepository.Add(company);
            }
            catch (Exception ex)
            {
                Notify(ex.Message);
                return null;
            }
            return company;
        }

        public async Task<Company> Update(Company company)
        {
            if (!ExecuteValidation(new CompanyValidation(), company)) return null;

            if (_companyRepository.Get(c => c.Document == company.Document && c.Id != company.Id).Result.Any())
            {
                Notify("Company does not exists.");

                return null;
            }

            await _companyRepository.Update(company);
            return null;
        }

        public async Task UpdateAddress(Address address)
        {
            if (!ExecuteValidation(new AddressValidation(), address)) return;

            await _addressRepository.Update(address);
        }

        public async Task<bool> Delete(Guid id)
        {
            if (_companyRepository.GetCompanyJobOffersAddress(id).Result.JobOffers.Any())
            {
                Notify("The company has registered contracts.");
                return false;
            }

            var address = await _addressRepository.GetAddressByCompany(id);

            if (address != null)
            {
                await _addressRepository.Delete(address.Id);
            }

            await _companyRepository.Delete(id);
            return false;

        }
    }
}