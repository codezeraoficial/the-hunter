using Service.ViewModels;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserCombineService
    {
        Task<UserCombineViewModel> GotchaUser(UserCombineViewModel  userCombineViewModel);
        Task<UserCombineViewModel> DropUser(UserCombineViewModel userCombineViewModel);
    }
}
