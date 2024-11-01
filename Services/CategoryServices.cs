namespace uts_frontend_72220561.Services
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Models;

    public class CategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Category>>("https://actualbackendapp.azurewebsites.net/api/v1/Categories");
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            // Correctly interpolate the categoryId in the URL
            var response = await _httpClient.DeleteAsync($"https://actualbackendapp.azurewebsites.net/api/v1/Categories/{categoryId}");

            // Check if the response is successful
            if (response.IsSuccessStatusCode)
            {
                return true; // Successfully deleted
            }
            else
            {
                // Log the error response for debugging
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error deleting category: {response.StatusCode} - {errorContent}");
                return false; // Deletion failed
            }
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            try
            {
                // Log outgoing data for debugging
                Console.WriteLine($"Sending PUT request for Category: {category.CategoryId}, {category.Name}, {category.Description}");

                // Ensure full URL with ID is used for the update
                var response = await _httpClient.PutAsJsonAsync(
                    $"https://actualbackendapp.azurewebsites.net/api/v1/Categories/{category.CategoryId}",
                    category
                );

                // Log response status for easier debugging
                Console.WriteLine($"API Response: {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    return true; // Update successful
                }
                else
                {
                    // Log the response content to diagnose issues
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Failed to update: {response.StatusCode} - {errorContent}");
                    return false; // Update failed
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in UpdateCategoryAsync: {ex.Message}");
                return false; // Return false in case of exception
            }
        }


        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://actualbackendapp.azurewebsites.net/api/v1/Categories/{categoryId}");


                if (response.IsSuccessStatusCode)
                {
                    var category = await response.Content.ReadFromJsonAsync<Category>();
                    return category; // Return the category if found
                }
                else
                {
                    // Log the response for debugging
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {response.StatusCode} - {errorContent}");
                    return null; // Return null if not found or an error occurs
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null; // Return null if an exception occurs
            }
        }

        public async Task<string> CreateCategoryAsync(Category newCategory)
        {
            try
            {
                // Use the correct full URL for the POST request
                var response = await _httpClient.PostAsJsonAsync(
                    "https://actualbackendapp.azurewebsites.net/api/v1/Categories",
                    newCategory
                );

                if (response.IsSuccessStatusCode)
                {
                    return "Success"; // Category created successfully
                }
                else
                {
                    // Log the response content for troubleshooting
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Failed to create category: {response.StatusCode} - {errorContent}");
                    return $"Failed: {response.StatusCode} - {errorContent}";
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during the request
                Console.WriteLine($"Exception in CreateCategoryAsync: {ex.Message}");
                return $"Exception: {ex.Message}";
            }
        }
    }
}
