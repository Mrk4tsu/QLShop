using System.Threading.Tasks;
using Users.ViewModels.System.Users;

namespace Users.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}
