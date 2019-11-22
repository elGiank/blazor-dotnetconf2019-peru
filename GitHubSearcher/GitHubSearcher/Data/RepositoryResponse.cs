using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GitHubSearcher.Data
{
    public class RepositoryResponse
    {
        [JsonPropertyName("items")]
        public List<Repository> Repositories { get; set; }
    }
}
