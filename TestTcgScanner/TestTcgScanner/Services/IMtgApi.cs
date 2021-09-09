using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using TestTcgScanner.Models;

namespace TestTcgScanner.Services
{
    public interface IMtgApi
    {
        [Get("/cards")]
        Task<ApiResponse<MtgSearchResult>> GetCards(MtgSearchParams searchParams);
    }
}
