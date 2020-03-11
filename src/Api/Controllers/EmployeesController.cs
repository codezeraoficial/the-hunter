using AutoMapper;
using Repository.Interfaces;
using Service.Interfaces;
using Domain.Models;
using Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/employees")]
    public class EmployeesController : MainController
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper, IEmployeeService employeeService)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            var employees = _mapper.Map<IEnumerable<EmployeeViewModel>>(await _employeeRepository.GetAll());
            return employees;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EmployeeViewModel>> GetById(Guid Id)
        {
            var employee = await GetEmployeeTechsSkillsOccupations(Id);

            if (employee == null) return NotFound();

            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeViewModel>> Add(EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var employee = _mapper.Map<Employee>(employeeViewModel);

            var result = _mapper.Map<EmployeeViewModel>(await _employeeService.Add(employee));

            if (result == null) return BadRequest();

            return Ok(result);

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<EmployeeViewModel>> Update(Guid Id, EmployeeViewModel employeeViewModel)
        {
            if (Id != employeeViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var employee = _mapper.Map<Employee>(employeeViewModel);
            var result = _mapper.Map<EmployeeViewModel>(await _employeeService.Update(employee));

            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<EmployeeViewModel>> Delete(Guid Id)
        {
            var employee = await GetEmployeeAddress(Id);

            if (employee == null) return NotFound();

            await _employeeService.Delete(Id);

            return Ok(employee);
        }

        public async Task<EmployeeViewModel> GetEmployeeTechsSkillsOccupations(Guid Id)
        {
            return _mapper.Map<EmployeeViewModel>(await _employeeRepository.GetEmployeeAddressTechsSkillsOccupations(Id));
        }

        public async Task<EmployeeViewModel> GetEmployeeAddress(Guid Id)
        {
            return _mapper.Map<EmployeeViewModel>(await _employeeRepository.GetEmployeeAddress(Id));
        }
    }
}