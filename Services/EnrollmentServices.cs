namespace uts_frontend_72220561.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Models;

    public class EnrollmentService
    {
        private readonly HttpClient _httpClient;

        public EnrollmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Instructors>> GetAllInstructorsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Instructors>>("https://actbackendseervices.azurewebsites.net/api/instructors");
        }

        public async Task<List<Enrollments>> GetEnrollmentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Enrollments>>("https://actbackendseervices.azurewebsites.net/api/enrollments");
        }

        public async Task CreateEnrollmentAsync(Enrollments enrollment)
        {
            var response = await _httpClient.PostAsJsonAsync("https://actbackendseervices.azurewebsites.net/api/enrollments", enrollment);
            response.EnsureSuccessStatusCode();
        }
    }
}
