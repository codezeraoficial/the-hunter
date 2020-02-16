using GoHunter.Business.Interfaces;
using GoHunter.Business.Models;
using GoHunter.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace GoHunter.Business.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        public async Task Add(Employee employee)
        {
            if (!ExecutarValidacao(new EmployeeValidation(), employee)) return;
        }

        public async Task Update(Employee employee)
        {
            if (!ExecutarValidacao(new EmployeeValidation(), employee)) return;
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
