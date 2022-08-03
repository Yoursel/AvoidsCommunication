using AvoidsCommunication.Domain.Response;
using AvoidsCommunication.Domain.ViewModel.User;
using System.Security.Claims;


namespace AvoidsCommunication.Service.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
    }
}
