using Service.Interfaces;
using Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/techs")]
    public class TechController : MainController
    {
        private readonly ITechService _techService;

        public TechController(ITechService techService, INotifier notifier) : base(notifier)
        {
            _techService = techService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechViewModel>>> GetAll()
        {
            var result = await _techService.GetAll();
            return Ok(result);           
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TechViewModel>> GetById(Guid id)
        {
            var result = await _techService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TechViewModel>> Add(TechViewModel techViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(await _techService.Add(techViewModel));
        }

        [HttpPut]
        public async Task<ActionResult<TechViewModel>> Update(TechViewModel techViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(await _techService.Update(techViewModel));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TechViewModel>> Delete(Guid Id)
        {
            return CustomResponse(await _techService.Delete(Id));
        }
    }
}