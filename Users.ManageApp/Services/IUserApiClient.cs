using System.Threading.Tasks;
using Users.ViewModels.System.Users;

namespace Users.ManageApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
