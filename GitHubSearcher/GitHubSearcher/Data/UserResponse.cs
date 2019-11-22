using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GitHubSearcher.Data
{
    public class UserResponse
    {
        [JsonPropertyName("items")]
        public List<User> Users { get; set; }
          
    }
}
