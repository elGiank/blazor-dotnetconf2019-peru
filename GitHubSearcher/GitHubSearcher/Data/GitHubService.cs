using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GitHubSearcher.Data
{
    public class GitHubService
    {
        public HttpClient Client { get; }

        public GitHubService()
        {
            Client = new HttpClient();

            Client.BaseAddress = new Uri("https://api.github.com/");
            // GitHub API versioning
            Client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            // GitHub requires a user-agent
            Client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample"); //TODO: may I change the user agent?
        }


        public async Task<UserResponse> FindGitHubUsersAsync(string userName)
        {
            var response = await Client.GetAsync($"search/users?q={userName}+repos:>0");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<UserResponse>(responseStream);
        }
    }
}
