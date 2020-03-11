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
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService companyService)
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
            if (!ModelState.IsValid) 
                return BadRequest();

            var result = _mapper.Map<CompanyViewModel>(await _companyService.Add(companyViewModel));

            if (result == null) 
                return BadRequest();

            return Ok(result);

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CompanyViewModel>> Update(CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _companyService.Update(companyViewModel);

            if (result == null) 
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var deleted = await _companyService.Delete(Id);

            if (!deleted)
                return BadRequest();

            return Ok();
        }
    }
}
