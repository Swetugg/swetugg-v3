using System.Text.Json;

namespace Swetugg.Web.Services;

public class EventManager
{
    private readonly HttpClient _httpClient;
    public EventManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<Event>> GetEventsAsync()
    {
        //var response = await _httpClient.GetAsync("events");
        //response.EnsureSuccessStatusCode();
        //var content = await response.Content.ReadAsStringAsync();
        //return JsonSerializer.Deserialize<IEnumerable<Event>>(content);

        return Task.FromResult(new List<Event>
        {
            new Event(1, 2025, City.Stockholm, CfpStage.Closed, true),
            new Event(2, 2025, City.Goteborg, CfpStage.SpeakersSelected)
        }).Result;
    }
    public async Task<Event> GetEventAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"events/{id}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Event>(content);
    }
    //public async Task<Event> CreateEventAsync(Event @event)
    //{
    //    var json = JsonSerializer.Serialize(@event);
    //    var response = await _httpClient.PostAsync("events", new StringContent(json, Encoding.UTF8, "application/json"));
    //    response.EnsureSuccessStatusCode();
    //    var content = await response.Content.ReadAsStringAsync();
    //    return JsonSerializer.Deserialize<Event>(content);
    //}
    //public async Task UpdateEventAsync(Guid id, Event @event)
    //{
    //    var json = JsonSerializer.Serialize(@event);
    //    var response = await _httpClient.PutAsync($"events/{id}", new StringContent(json, Encoding.UTF8, "application/json"));
    //    response.EnsureSuccessStatusCode();
    //}
    //public async Task DeleteEventAsync(Guid id)
    //{
    //    //var response = await _httpClient.DeleteAsync($"events/{id}");
    //    // set soft delete of event
    //    var response = await _httpClient.PatchAsync($"events/{id}", new StringContent("", Encoding.UTF8, "application/json"));
    //    response.EnsureSuccessStatusCode();
    //}
}

public record Event(int Id, int Year, City City, CfpStage CfpStage, bool IsCurrent = false);

public enum City
{
    Stockholm,
    Goteborg
}

public enum CfpStage
{
    NotStarted,
    Open,
    Closed,
    SpeakersSelected
}
