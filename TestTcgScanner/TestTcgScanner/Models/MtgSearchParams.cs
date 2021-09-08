using System.Collections.Generic;
using Refit;

namespace TestTcgScanner.Models
{
    public class MtgSearchParams
    {
        [AliasAs("name")]
        public string? Name { get; set; }

        [AliasAs("number")]
        public string? Number { get; set; }

        [AliasAs("id")]
        public int? Id { get; set; }

        [AliasAs("type")]
        public string? Type { get; set; }

        [AliasAs("set")]
        public string? Set { get; set; }

        [AliasAs("setName")]
        public string? SetName { get; set; }

        [AliasAs("text")]
        public string? Text { get; set; }
    }
}
