using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Users.ViewModels.Base;
using Users.ViewModels.System.Users;

namespace Users.ManageApp.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        public UserApiClient(IHttpClientFactory httpClientFactory,IHttpContextAccessor httpContextAccessor,IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<APIResult<string>> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PostAsync("/api/users/authenticate", httpContent);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISucessResult<string>>(await response.Content.ReadAsStringAsync());
            }
            return JsonConvert.DeserializeObject<APIErrorResult<string>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<APIResult<UserVModel>> GetById(Guid id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/users/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISucessResult<UserVModel>>(body);

            return JsonConvert.DeserializeObject<APIErrorResult<UserVModel>>(body);
        }

        public async Task<APIResult<PagedResult<UserVModel>>> GetUsersPagings(GetUserPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/users/paging?pageIndex=" +
				$"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");
			var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<APISucessResult<PagedResult<UserVModel>>>(body);
            return users;
		}

        public async Task<APIResult<bool>> RegisterUser(RegisterRequest registerRequest)
        {
			var client = _httpClientFactory.CreateClient();
			client.BaseAddress = new Uri(_configuration["BaseAddress"]);

			var json = JsonConvert.SerializeObject(registerRequest);
			var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await client.PostAsync($"/api/users", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISucessResult<bool>>(result);

            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(result);
        }
        public async Task<APIResult<bool>> UpdateUser(Guid id, UserUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/users/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISucessResult<bool>>(result);

            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(result);
        }
    }
}
