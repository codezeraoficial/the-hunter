using AutoMapper;
using Domain.Models;
using Repository.Interfaces;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserCombineService: BaseService, IUserCombineService
    {

        private readonly IUserCombineRepository _userCombineRepository;
        private readonly IMapper _mapper;
        public UserCombineService(IUserCombineRepository userCombineRepository, INotifier notifier,
                                   IMapper mapper) : base(notifier)
        {
            _userCombineRepository = userCombineRepository;
            _mapper = mapper;
        }
        public async Task<UserCombineViewModel> GotchaUser(UserCombineViewModel userCombineViewModel)
        {
            var userCombine = _mapper.Map<UserCombine>(userCombineViewModel);
            userCombine.DoGotcha();

            if (_userCombineRepository.Get(u => u.Id == userCombine.Id).Result.Any())
            {
                Notify("Invalid parameters.");
                return null;
            }

            if (userCombine.JobOfferId == null && userCombine.EmployeeId == null)
                return null;

            await _userCombineRepository.Add(userCombine);
            
            return _mapper.Map<UserCombineViewModel>(userCombine);
        }

        public async Task<UserCombineViewModel> DropUser(UserCombineViewModel userCombineViewModel)
        {
            var userCombine = _mapper.Map<UserCombine>(userCombineViewModel);
            userCombine.DoDropped();

            if (!_userCombineRepository.Get(u => u.Id == userCombine.Id).Result.Any())
            {
                Notify("Invalid parameters.");
                return null;
            }

            await _userCombineRepository.Update(userCombine);

            return _mapper.Map<UserCombineViewModel>(userCombine);
        }
        
        public void Dispose()
        {
            _userCombineRepository?.Dispose();
        }

    }
}
