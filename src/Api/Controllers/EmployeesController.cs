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
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService, INotifier notifier) : base(notifier)
        {
            _employeeService = employeeService;
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