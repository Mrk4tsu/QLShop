using System.Threading.Tasks;
using Users.ViewModels.Base;
using Users.ViewModels.System.Users;

namespace Users.ManageApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PagedResult<UserVModel>> GetUserPaging(GetUserPagingRequest request);
    }
}
