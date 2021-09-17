using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

using Refit;

using TestTcgScanner.Models;

namespace TestTcgScanner.Services
{
    public class MtgApiService : IMtgApi
    {
        private readonly IMtgApi _mtgApiClient;
        public MtgApiService(IMtgApi mtgApiClient) => _mtgApiClient = mtgApiClient;

        public async Task<ApiResponse<MtgSearchResult>> GetCards(MtgSearchParams searchParams) => await _mtgApiClient.GetCards(searchParams);
    }
}
