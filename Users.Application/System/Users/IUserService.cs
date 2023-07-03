using System;
using System.Threading.Tasks;
using Users.ViewModels.Base;
using Users.ViewModels.System.Users;

namespace Users.Application.System.Users
{
    public interface IUserService
    {
        Task<APIResult<string>> Authencate(LoginRequest request);
        Task<APIResult<bool>> Register(RegisterRequest request);
        Task<APIResult<PagedResult<UserVModel>>> GetUsersPaging(GetUserPagingRequest request);
        Task<APIResult<bool>> Update(Guid id, UserUpdateRequest request);
        Task<APIResult<UserVModel>> GetById(Guid id);
    }
}
