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
    public class OccupationService : BaseService, IOccupationService
    {
        private readonly IOccupationRepository _occupationRepository;
        private readonly IMapper _mapper;

        public OccupationService(IOccupationRepository occupationRepository, 
                                   INotifier notifier,
                                   IMapper mapper) : base(notifier)
        {
            _occupationRepository = occupationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OccupationViewModel>> GetAll()
        {
            return  _mapper.Map<IEnumerable<OccupationViewModel>>(await _occupationRepository.GetAll());
        }

        public async Task<OccupationViewModel> GetById(Guid id)
        {
            return _mapper.Map<OccupationViewModel>(await _occupationRepository.GetById(id));
        }

        public async Task<OccupationViewModel> Add(OccupationViewModel occupationViewModel)
        {
            var occupation = _mapper.Map<Occupation>(occupationViewModel);
            //occupation.Id = new Guid();

            if (!ExecuteValidation(new OccupationValidation(), occupation)) return null;

            if(_occupationRepository.Get(o=>o.Id == occupation.Id).Result.Any())
            {
                Notify("Invalid parameters.");
                return null;
            }

            await _occupationRepository.Add(occupation);

            return _mapper.Map<OccupationViewModel>(occupation);
        }

        public async Task<OccupationViewModel> Update(OccupationViewModel occupationViewModel)
        {
            var occupation = _mapper.Map<Occupation>(occupationViewModel);

            if (!ExecuteValidation(new OccupationValidation(), occupation)) return null;

            if(!_occupationRepository.Get(o=>o.Id == occupation.Id).Result.Any())
            {
                Notify("The occupation does not exists.");
                return null;
            }

            await _occupationRepository.Update(occupation);

            return _mapper.Map<OccupationViewModel>(occupation);
        }

        public async Task<bool> Delete(Guid id)
        {
            if (!_occupationRepository.Get(o => o.Id == id).Result.Any())
            {
                Notify("The occupation does not exists.");
                return false;
            }

            await _occupationRepository.Delete(id);

            return true;
        }

        public void Dispose()
        {
            _occupationRepository?.Dispose();
        }

    }
}
