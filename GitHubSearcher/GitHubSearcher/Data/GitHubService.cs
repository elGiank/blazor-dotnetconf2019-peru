using System;
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
            Client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            Client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
        }


        public async Task<UserResponse> FindGitHubUsersAsync(string userName)
        {
            var response = await Client.GetAsync($"search/users?q={userName}+repos:>0");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<UserResponse>(responseStream);
        }

        public async Task<RepositoryResponse> FindRepositories(string query)
        {
            var response = await Client.GetAsync($"search/repositories?q={query}&sort=stars&order=desc");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<RepositoryResponse>(responseStream);
        }
    }
}
