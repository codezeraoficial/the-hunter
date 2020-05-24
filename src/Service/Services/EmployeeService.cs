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
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository,
            IMapper mapper, INotifier notifier,
            IAddressService addressService) : base(notifier)
        {
            _addressService = addressService;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<EmployeeViewModel>>(await _employeeRepository.Get(e=> !e.Removed));
        }

        public async Task<EmployeeViewModel> GetById(Guid id)
        {
            return _mapper.Map<EmployeeViewModel>(await _employeeRepository.GetEmployeeAddressTechsSkillsOccupations(id));
        }

        public async Task<EmployeeViewModel> Add(EmployeeViewModel employeeViewModel)
        {
            var employee = _mapper.Map<Employee>(employeeViewModel);


            if (!ExecuteValidation(new EmployeeValidation(), employee)) return null;

            if (_employeeRepository.Get(e=> e.Document == employee.Document).Result.Any())
            {
                Notify("There is already a employee with the document informed.");

                return null;
            }

            var address = await _addressService.Add(employeeViewModel.Address);

            employee.LinkAddress(employee.AddressId);

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

            await _addressService.Update(employeeViewModel.Address, true);


            await _employeeRepository.Update(employee);
            return _mapper.Map<EmployeeViewModel>(employee);
        }


        public async Task<bool> Delete(Guid id)
        {
            var employee = await _employeeRepository.GetById(id);

            if (employee == null)
            {
                Notify("Employee does not exists.");

                return false;
            }       

            employee.Remove();

            await _addressService.Delete(id);

            await _employeeRepository.Delete(id);

            await _employeeRepository.Update(employee);

            return true;
        }

        public void Dispose()
        {
            _employeeRepository?.Dispose();
        }

    }
}
