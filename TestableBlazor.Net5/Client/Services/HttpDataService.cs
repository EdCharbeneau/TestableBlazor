using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TestableBlazor.Net5.Client.Services
{
    public class HttpDataService : IDataService
    {
        private readonly HttpClient http;
        public HttpDataService(HttpClient http) => this.http = http;
        public Task<string[]> GetRegions()
        {
            return http.GetFromJsonAsync<string[]>("api/values");
        }

        public Task<string[]> GetTeamsByRegion(string region)
        {
            return http.GetFromJsonAsync<string[]>($"api/values/{region}");
        }
    }

}
