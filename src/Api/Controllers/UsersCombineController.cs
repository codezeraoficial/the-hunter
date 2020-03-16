using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.ViewModels;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/usersCombine")]
    public class UsersCombineController : MainController
    {
        private readonly IUserCombineService _userCombineService;

        public UsersCombineController(IUserCombineService userCombineService, INotifier notifier) : base(notifier)
        {
            _userCombineService = userCombineService;
        }
                

        [HttpPost]
        public async Task<ActionResult<UserCombineViewModel>> Gotcha(UserCombineViewModel userCombineViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(await _userCombineService.GotchaUser(userCombineViewModel));
        }

        [HttpPost]
        public async Task<ActionResult<UserCombineViewModel>> Dropped(UserCombineViewModel userCombineViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(await _userCombineService.DropUser(userCombineViewModel));
        }

    }
}