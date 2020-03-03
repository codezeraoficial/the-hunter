using GoHunter.Business.Interfaces;
using GoHunter.Business.Models;
using GoHunter.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GoHunter.Business.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAddressRepository _addressRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IAddressRepository addressRepository, INotifier notifier): base(notifier)
        {
            _addressRepository = addressRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task Add(Employee employee)
        {
            if (!ExecuteValidation(new EmployeeValidation(), employee)
                || !ExecuteValidation(new AddressValidation(), employee.Address)) return;

            if (_employeeRepository.Get(e=> e.Document == employee.Document).Result.Any())
            {
                Notify("There is already a employee with the document informed.");

                return;
            }

            await _employeeRepository.Add(employee);

        }

        public async Task Update(Employee employee)
        {
            if (!ExecuteValidation(new EmployeeValidation(), employee)) return;

            if (_employeeRepository.Get(e=>e.Document == employee.Document && e.Id != employee.Id).Result.Any())
            {
                Notify("Employee does not exists.");

                return;
            }

            await _employeeRepository.Update(employee);
        }

        public async Task UpdateAddress(Address address)
        {
            if (!ExecuteValidation(new AddressValidation(), address)) return;

            await _addressRepository.Update(address);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _addressRepository?.Dispose();
            _employeeRepository?.Dispose();
        }

    }
}
