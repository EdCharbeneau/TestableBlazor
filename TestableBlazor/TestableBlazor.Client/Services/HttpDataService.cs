using System.Net.Http.Json;

namespace TestableBlazor.Client.Services
{
    public class HttpDataService : IDataService
    {
        private readonly HttpClient http;
        public HttpDataService(HttpClient http) => this.http = http;
        public async Task<string[]> GetRegions()
        {
            return await http.GetFromJsonAsync<string[]>("api/values") ??
                throw new InvalidOperationException("This web api does not return nulls");
        }

        public async Task<string[]> GetTeamsByRegion(string region)
        {
            return await http.GetFromJsonAsync<string[]>($"api/values/{region}") ??
                throw new InvalidOperationException("This web api does not return nulls");
        }
    }

}
