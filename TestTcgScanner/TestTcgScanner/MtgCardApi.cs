using System.Net.Http;
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
            using var client = _clientFactory.CreateClient();
            client.GetAsync("");

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
