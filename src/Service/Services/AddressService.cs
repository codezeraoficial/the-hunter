using AutoMapper;
using Domain.Models;
using Domain.Models.Validations;
using Repository.Interfaces;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AddressService : BaseService, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper, INotifier notifier) : base(notifier)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<AddressViewModel> Add(AddressViewModel addressViewModel)
        {
            var address = _mapper.Map<Address>(addressViewModel);

            if (!ExecuteValidation(new AddressValidation(), address)) return null;


            return _mapper.Map<AddressViewModel>(address);
        }


        public async Task<AddressViewModel> Update(AddressViewModel addressViewModel, bool ignoreUpdate)
        {
            if (addressViewModel == null)
                return null;

            var address = _mapper.Map<Address>(addressViewModel);

            if (!ExecuteValidation(new AddressValidation(), address)) return null;

            if (!ignoreUpdate)
                await _addressRepository.Update(address);

            return _mapper.Map<AddressViewModel>(address);

        }

        public Task<IEnumerable<AddressViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AddressViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid Id)
        {
            var address = await _addressRepository.GetById(Id);

            if (address == null)
                return false;

            address.Remove();

            await _addressRepository.Update(address);

            return true;
        }
    }
}
