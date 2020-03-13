using AutoMapper;
using Domain.Models;
using Domain.Models.Validations;
using Repository.Interfaces;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TechService : BaseService, ITechService
    {
        private readonly ITechRepository _techRepository;
        private readonly IMapper _mapper;

        public TechService(ITechRepository techRepository, 
                                   INotifier notifier,
                                   IMapper mapper) : base(notifier)
        {
            _techRepository = techRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TechViewModel>> GetAll()
        {
            return  _mapper.Map<IEnumerable<TechViewModel>>(await _techRepository.GetAll());
        }

        public async Task<TechViewModel> GetById(Guid id)
        {
            return _mapper.Map<TechViewModel>(await _techRepository.GetById(id));
        }

        public async Task<TechViewModel> Add(TechViewModel techViewModel)
        {
            var tech = _mapper.Map<Tech>(techViewModel);
            tech.Id = new Guid();

            if (!ExecuteValidation(new TechValidation(), tech)) return null;

            if(_techRepository.Get(o=>o.Id == tech.Id).Result.Any())
            {
                Notify("Invalid parameters.");
                return null;
            }

            await _techRepository.Add(tech);

            return _mapper.Map<TechViewModel>(tech);
        }

        public async Task<TechViewModel> Update(TechViewModel techViewModel)
        {
            var tech = _mapper.Map<Tech>(techViewModel);

            if (!ExecuteValidation(new TechValidation(), tech)) return null;

            if(!_techRepository.Get(o=>o.Id == tech.Id).Result.Any())
            {
                Notify("The tech does not exists.");
                return null;
            }

            await _techRepository.Update(tech);

            return _mapper.Map<TechViewModel>(tech);
        }

        public async Task<bool> Delete(Guid id)
        {
            if (!_techRepository.Get(o => o.Id == id).Result.Any())
            {
                Notify("The tech does not exists.");
                return false;
            }

            await _techRepository.Delete(id);

            return true;
        }

        public void Dispose()
        {
            _techRepository?.Dispose();
        }

    }
}
