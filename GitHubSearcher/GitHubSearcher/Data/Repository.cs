using System;
using System.Text.Json.Serialization;
namespace GitHubSearcher.Data
{
    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("html_url")]
        public string RepoUrl { get; set; }

        [JsonPropertyName("owner")]
        public User User { get; set; }

    }
}
