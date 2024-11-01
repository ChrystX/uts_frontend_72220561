namespace uts_frontend_72220561.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Models;
    public class CourseService
    {
        private readonly HttpClient _httpClient;

        public CourseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Course>>("/api/Courses") ?? new List<Course>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching courses: {ex.Message}");
                return new List<Course>(); // Return empty list if something goes wrong
            }
        }

        public async Task<bool> CreateCourseAsync(Course course)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(
                    "https://actualbackendapp.azurewebsites.net/api/Courses", course);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating course: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteCourseAsync(int courseId)
        {
            var response = await _httpClient.DeleteAsync($"https://actualbackendapp.azurewebsites.net/api/Courses/{courseId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await _httpClient.GetFromJsonAsync<Course>($"https://actualbackendapp.azurewebsites.net/api/Courses/{courseId}");
        }

        public async Task<bool> UpdateCourseAsync(CourseUpdateDto courseDto)
        {
            // Ensure that the CourseId is properly included in the URL
            var response = await _httpClient.PutAsJsonAsync(
                $"https://actualbackendapp.azurewebsites.net/api/Courses/{courseDto.CourseId}",
                courseDto
            );

            // Log the status code for debugging purposes
            Console.WriteLine($"Update Response Status: {response.StatusCode}");

            // Return whether the response was successful
            return response.IsSuccessStatusCode;
        }
    }
}
