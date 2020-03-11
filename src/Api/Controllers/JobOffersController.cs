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
    [Route("api/joboffers")]
    public class JobOffersController : MainController
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IJobOfferService _jobOfferService;
        private readonly IMapper _mapper;

        public JobOffersController(IJobOfferRepository jobOfferRepository, IJobOfferService jobOfferService, IMapper mapper)
        {
            _jobOfferRepository = jobOfferRepository;
            _jobOfferService = jobOfferService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<JobOfferViewModel>> GetAll()
        {
            var jobOffers = _mapper.Map<IEnumerable<JobOfferViewModel>>(await _jobOfferRepository.GetAll());
            return jobOffers;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<JobOfferViewModel>> GetById(Guid Id)
        {
            var jobOffer = await GetJobOfferCompanyOccupation(Id);
            if (jobOffer == null) return NotFound();
            return jobOffer;
        }

        [HttpPost]
        public async Task<ActionResult<JobOfferViewModel>> Add(JobOfferViewModel jobOfferViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var jobOffer = _mapper.Map<JobOffer>(jobOfferViewModel);

            var result = _mapper.Map<JobOfferViewModel>(await _jobOfferService.Add(jobOffer));

            if (result == null) return BadRequest();

            return Ok(result);

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<JobOfferViewModel>> Update(Guid Id, JobOfferViewModel jobOfferViewModel)
        {
            if (Id != jobOfferViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var jobOffer = _mapper.Map<JobOffer>(jobOfferViewModel);
            var result = _mapper.Map<JobOfferViewModel>(await _jobOfferService.Update(jobOffer));

            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<JobOfferViewModel>> Delete(Guid Id)
        {
            var jobOffer = await GetJobOfferCompany(Id);

            if (jobOffer == null) return NotFound();

            await _jobOfferService.Delete(Id);

            return Ok(jobOffer);
        }

        public async Task<JobOfferViewModel> GetJobOfferCompany(Guid Id)
        {
            return _mapper.Map<JobOfferViewModel>(await _jobOfferRepository.GetJobOfferCompany(Id));
        } 
        
        public async Task<JobOfferViewModel> GetJobOfferCompanyOccupation(Guid Id)
        {
            return _mapper.Map<JobOfferViewModel>(await _jobOfferRepository.GetJobOfferCompanyOccupation(Id));
        }
    }
}