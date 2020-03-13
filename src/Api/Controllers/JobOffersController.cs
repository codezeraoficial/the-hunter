using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/joboffers")]
    public class JobOffersController : MainController
    {
        private readonly IJobOfferService _jobOfferService;

        public JobOffersController(IJobOfferService jobOfferService, INotifier notifier) : base(notifier)
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