namespace uts_frontend_72220561.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Models;

    public class UserService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://actbackendseervices.azurewebsites.net/api/users";
        private const string LoginUrl = "https://actbackendseervices.azurewebsites.net/api/login";
        private const string RoleUrl = "https://actbackendseervices.azurewebsites.net/api/roles";
        private const string RegisterUserRoleUrl = "https://actbackendseervices.azurewebsites.net/api/registeruserrole";

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> RegisterUserAsync(User newUser)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, newUser);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return "Success";
            }
            else
            {
                return $"Failed: {response.StatusCode} - {responseContent}";
            }
        }

        public async Task<string> LoginUserAsync(LoginUser loginUser)
        {
            var response = await _httpClient.PostAsJsonAsync(LoginUrl, loginUser);

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return $"Success: {loginResponse.Token}";
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return $"Failed: {response.StatusCode} - {responseContent}";
            }
        }

        public async Task<string> CreateRoleAsync(Role role)
        {
            var response = await _httpClient.PostAsJsonAsync(RoleUrl, role);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return "Success";
            }
            else
            {
                return $"Failed: {response.StatusCode} - {responseContent}";
            }
        }

        public async Task<string> RegisterUserRoleAsync(UserRole userRole)
        {
            var response = await _httpClient.PostAsJsonAsync(RegisterUserRoleUrl, userRole);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return "Success";
            }
            else
            {
                return $"Failed: {response.StatusCode} - {responseContent}";
            }
        }
    }
}
