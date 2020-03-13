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
        private readonly IJobOfferService _jobOfferService;

        public JobOffersController(IJobOfferService jobOfferService, IMapper mapper, INotifier notifier) : base(notifier)
        {
            _jobOfferService = jobOfferService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobOfferViewModel>>> GetAll()
        {
            var result = await _jobOfferService.GetAll();
            return Ok(result);           
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<JobOfferViewModel>> GetById(Guid id)
        {
            var result = await _jobOfferService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<JobOfferViewModel>> Add(JobOfferViewModel jobOfferViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(await _jobOfferService.Add(jobOfferViewModel));

        }

        [HttpPut]
        public async Task<ActionResult<JobOfferViewModel>> Update(JobOfferViewModel jobOfferViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(await _jobOfferService.Update(jobOfferViewModel));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<JobOfferViewModel>> Delete(Guid Id)
        {
            return CustomResponse(await _jobOfferService.Delete(Id));
        }
    }
}