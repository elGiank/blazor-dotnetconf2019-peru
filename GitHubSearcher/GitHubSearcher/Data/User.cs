using System;
using System.Text.Json.Serialization;

namespace GitHubSearcher.Data
{
    public class User
    {
        [JsonPropertyName("login")]
        public string UserName { get; set; }

        [JsonPropertyName("avatar_url")]
        public string GrabatarUrl { get; set; }

        [JsonPropertyName("html_url")]
        public string ProfileUrl { get; set; }

        [JsonPropertyName("score")]
        public double Score { get; set; }

        //[JsonPropertyName("repos_url")]
        public string ReposUrl => $"{ProfileUrl}?tab=repositories";

    }
}
