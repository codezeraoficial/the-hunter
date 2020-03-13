using Repository.Interfaces;
using Service.Interfaces;
using Domain.Models;
using Domain.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using Service.ViewModels;

namespace Service.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IAddressRepository addressRepository, IMapper mapper, INotifier notifier): base(notifier)
        {
            _addressRepository = addressRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<EmployeeViewModel>>(await _employeeRepository.GetAll());
        }

        public async Task<EmployeeViewModel> GetById(Guid id)
        {
            return _mapper.Map<EmployeeViewModel>(await _employeeRepository.GetEmployeeAddressTechsSkillsOccupations(id));
        }

        public async Task<EmployeeViewModel> Add(EmployeeViewModel employeeViewModel)
        {
            var employee = _mapper.Map<Employee>(employeeViewModel);

            employee.Id = Guid.NewGuid();
            employee.AddressId = Guid.NewGuid();
            employee.Address.Id = employee.AddressId.Value;

            if (!ExecuteValidation(new EmployeeValidation(), employee)
                || !ExecuteValidation(new AddressValidation(), employee.Address)) return null;

            if (_employeeRepository.Get(e=> e.Document == employee.Document).Result.Any())
            {
                Notify("There is already a employee with the document informed.");

                return null;
            }

            await _employeeRepository.Add(employee);
            return _mapper.Map<EmployeeViewModel>(employee);

        }

        public async Task<EmployeeViewModel> Update(EmployeeViewModel employeeViewModel)
        {
            var employee = _mapper.Map<Employee>(employeeViewModel);

            if (!ExecuteValidation(new EmployeeValidation(), employee)) return null;

            if (!_employeeRepository.Get(e=>e.Id == employee.Id).Result.Any())
            {
                Notify("Employee does not exists.");

                return null;
            }

            await _employeeRepository.Update(employee);
            return _mapper.Map<EmployeeViewModel>(employee);
        }

        public async Task UpdateAddress(Address address)
        {
            if (!ExecuteValidation(new AddressValidation(), address)) return;

            await _addressRepository.Update(address);
        }

        public async Task<bool> Delete(Guid id)
        {
            if (!_employeeRepository.Get(e => e.Id == id).Result.Any())
            {
                Notify("Employee does not exists.");

                return false;
            }

            var address = await _addressRepository.GetAddressByEmployee(id);

            await _employeeRepository.Delete(id);

            if (address != null)
            {
                await _addressRepository.Delete(address.Id);
            }

            return true;
        }

        public void Dispose()
        {
            _addressRepository?.Dispose();
            _employeeRepository?.Dispose();
        }

    }
}
