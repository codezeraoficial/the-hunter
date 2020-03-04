using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GoHunter.Business.Interfaces;
using GoHunter.Business.Models;
using GoHunter.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GoHunter.Server.Controllers
{
    [Route("api/companies")]
    public class CompaniesController : MainController
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyRepository companyRepository, IMapper mapper, ICompanyService companyService)
        {
            _companyRepository = companyRepository;
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CompanyViewModel>> GetAll()
        {

            var companies = _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyRepository.GetAll());

            return companies;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CompanyViewModel>> GetById(Guid Id)
        {
            var company = await GetCompanyJobberOffersAddress(Id);

            if (company == null) return NotFound();

            return company;
        }

        [HttpPost]
        public async Task<ActionResult<CompanyViewModel>> Add(CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var company = _mapper.Map<Company>(companyViewModel);

            var result = _mapper.Map<CompanyViewModel>(await _companyService.Add(company));   

            return Ok(result);

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CompanyViewModel>> Update(Guid Id, CompanyViewModel companyViewModel)
        {
            if (Id != companyViewModel.Id) return BadRequest();

            if (ModelState.IsValid) return BadRequest();

            var company = _mapper.Map<Company>(companyViewModel);
            var result = await _companyService.Update(company);

            if (result != null) return BadRequest();

            return Ok(company);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CompanyViewModel>> Delete(Guid Id)
        {
            var company = await GetCompanyAddress(Id);

            if (company == null) return NotFound();

            var result = await _companyService.Delete(Id);

            if (result != null) return BadRequest();

            return Ok(company);
        }

        public async Task<CompanyViewModel> GetCompanyJobberOffersAddress(Guid Id)
        {
            return _mapper.Map<CompanyViewModel>(await _companyRepository.GetCompanyJobOffersAddress(Id));
        }

        public async Task<CompanyViewModel> GetCompanyAddress(Guid Id)
        {
            return _mapper.Map<CompanyViewModel>(await _companyRepository.GetCompanyAddress(Id));
        }
    }
}
