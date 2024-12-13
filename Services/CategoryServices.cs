namespace uts_frontend_72220561.Services
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Models;

    public class CategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly TokenService _tokenService;

        public CategoryService(HttpClient httpClient, TokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            _httpClient.BaseAddress = new Uri("https://actbackendseervices.azurewebsites.net/api/");
        }

        private void AddAuthorizationHeader()
        {
            if (!string.IsNullOrEmpty(_tokenService.AuthToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.AuthToken);
                Console.WriteLine($"Authorization Header: Bearer {_tokenService.AuthToken}");
            }
            else
            {
                Console.WriteLine("Authorization token is missing.");
            }
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            AddAuthorizationHeader();
            var response = await _httpClient.GetAsync("categories");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Category>>();
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request failed: {response.StatusCode} - {responseContent}");
            }
        }

        // Additional methods for DeleteCategoryAsync, UpdateCategoryAsync, etc.
        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            AddAuthorizationHeader();
            var response = await _httpClient.DeleteAsync($"categories/{categoryId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            AddAuthorizationHeader();
            var response = await _httpClient.PutAsJsonAsync($"categories/{category.CategoryId}", category);
            return response.IsSuccessStatusCode;
        }

        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            AddAuthorizationHeader();
            var response = await _httpClient.GetAsync($"categories/{categoryId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Category>();
            }
            else
            {
                return null;
            }
        }

        public async Task<string> CreateCategoryAsync(Category newCategory)
        {
            AddAuthorizationHeader();
            var response = await _httpClient.PostAsJsonAsync("categories", newCategory);
            if (response.IsSuccessStatusCode)
            {
                return "Success";
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return $"Failed: {response.StatusCode} - {responseContent}";
            }
        }
    }
}
