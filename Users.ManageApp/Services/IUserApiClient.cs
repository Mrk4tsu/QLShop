using System;
using System.Threading.Tasks;
using Users.ViewModels.Base;
using Users.ViewModels.System.Users;

namespace Users.ManageApp.Services
{
    public interface IUserApiClient
    {
        Task<APIResult<string>> Authenticate(LoginRequest request);
        Task<APIResult<PagedResult<UserVModel>>> GetUsersPagings(GetUserPagingRequest request);
        Task<APIResult<bool>> RegisterUser(RegisterRequest registerRequest);
        Task<APIResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);
        Task<APIResult<UserVModel>> GetById(Guid id);
    }
}
