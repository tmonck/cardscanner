using System.Net.Http;
using System.Web;
using Microsoft.Extensions.Http;

namespace TestTcgScanner
{
    public class MtgCardApi : ICardApi<MtgCard>
    {
        private IHttpClientFactory _clientFactory;
        public MtgCardApi(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }

        /// <inheritdoc/>
        public MtgCard LookUpCard(string name, string number, string set)
        {
            var queryString = $"?name={HttpUtility.UrlEncode(name)}&number={HttpUtility.UrlEncode(number)}&set={HttpUtility.UrlEncode(set)}";
            using var client = _clientFactory.CreateClient();
            client.GetAsync($"/v1/cards{queryString}");

            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public MtgCard LookUpCard(string name, string number)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public MtgCard LookUpCard(string name)
        {
            throw new NotImplementedException();
        }
    }
}
