using Service.Interfaces;
using Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/occupations")]
    public class OccupationController : MainController
    {
        private readonly IOccupationService _occupationService;

        public OccupationController(IOccupationService occupationService, INotifier notifier) : base(notifier)
        {
            _occupationService = occupationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OccupationViewModel>>> GetAll()
        {
            var result = await _occupationService.GetAll();
            return Ok(result);           
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OccupationViewModel>> GetById(Guid id)
        {
            var result = await _occupationService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<OccupationViewModel>> Add(OccupationViewModel occupationViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(await _occupationService.Add(occupationViewModel));

        }

        [HttpPut]
        public async Task<ActionResult<OccupationViewModel>> Update(OccupationViewModel occupationViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(await _occupationService.Update(occupationViewModel));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<JobOfferViewModel>> Delete(Guid Id)
        {
            return CustomResponse(await _occupationService.Delete(Id));
        }
    }
}