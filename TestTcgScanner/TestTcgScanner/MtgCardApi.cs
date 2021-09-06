using System.Net.Http;

namespace TestTcgScanner
{
    public class MtgCardApi : ICardApi<MtgCard>
    {
        private HttpClient _client;
        public MtgCardApi(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc/>
        public MtgCard LookUpCard(string name, string number, string set)
        {
            _client.GetAsync("");

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
