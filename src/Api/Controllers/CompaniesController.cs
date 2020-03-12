using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Service.Interfaces;
using Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/companies")]
    public class CompaniesController : MainController
    {
        private readonly ICompanyService _companyService;
        public CompaniesController(ICompanyService companyService, INotifier notifier): base(notifier)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyViewModel>>> GetAll()
        {
            var result = await _companyService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CompanyViewModel>> GetById(Guid id)
        {
            var result = await _companyService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyViewModel>> Add(CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(await _companyService.Add(companyViewModel));
        }

        [HttpPut]
        public async Task<ActionResult<CompanyViewModel>> Update(CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(await _companyService.Update(companyViewModel));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            return CustomResponse(await _companyService.Delete(Id));
        }
    }
}
