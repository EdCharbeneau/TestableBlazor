using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestableBlazor.Client.Services
{
    public interface IDataService
    {
        Task<string[]> GetRegions();
        Task<string[]> GetTeamsByRegion(string region);
    }
}
