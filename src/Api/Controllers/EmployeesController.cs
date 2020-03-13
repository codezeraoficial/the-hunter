using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Service.Interfaces;
using Service.ViewModels;
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

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper, IEmployeeService employeeService, INotifier notifier) : base(notifier)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeViewModel>>> GetAll()
        {
            var result = await _employeeService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EmployeeViewModel>> GetById(Guid Id)
        {
            var result = await _employeeService.GetById(Id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeViewModel>> Add(EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(await _employeeService.Add(employeeViewModel));

        }

        [HttpPut]
        public async Task<ActionResult<EmployeeViewModel>> Update(Guid Id, EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(await _employeeService.Update(employeeViewModel));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<EmployeeViewModel>> Delete(Guid Id)
        {
            return CustomResponse(await _employeeService.Delete(Id));
        }
    }
}