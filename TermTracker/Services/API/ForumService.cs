using System.Net.Http.Json;
using TermTracker.Models;
using TermTracker.Models.StudentLounge;

public class ForumService
{
    private readonly HttpClient _http;

    public ForumService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<ForumPost>> GetPostsAsync()
    {
        return await _http.GetFromJsonAsync<List<ForumPost>>("api/forum");
    }

    public async Task<bool> CreatePostAsync(ForumPost post)
    {
        var response = await _http.PostAsJsonAsync("api/forum", post);
        return response.IsSuccessStatusCode;
    }
}
