using TestableBlazor.Client.Services;

namespace TestableBlazor.Services
{
    public class DataService : IDataService
    {
        public Task<string[]> GetRegions() => 
            Task.FromResult(new string[] { "AE", "AM", "BI", "BJ", "BN", "BQ", "BR", "BS", "BW", "BY", "CA", "CD", "CH", "CL", "CM", "CN", "DE", "DJ", "ER", "ET", "GE", "GH", "GL", "GT", "GY", "HN", "HT", "HU", "ID", "IN", "IQ", "JO", "KW", "LA", "LB", "LR", "LT", "LU", "LY", "MC", "MD", "MU", "NA", "NG", "NI", "OM", "PK", "PL", "QA", "SB", "SD", "SH", "SK", "SN", "SO", "SR", "SS", "SV", "SY", "SZ", "TD", "TJ", "TL", "US", "UY", "UZ", "WS", "YE", "ZA", "ZW" });

        public Task<string[]> GetTeamsByRegion(string region) => 
            Task.FromResult(new string[] { $"Red {region}", $"Green {region}", $"Blue {region}" });
    }
}
