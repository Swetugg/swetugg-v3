using Swetugg.Services.Models;
using System.Text.Json;

namespace Swetugg.Services;

public class ConferenceManager
{
    private readonly HttpClient _httpClient;
    public ConferenceManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<ConferenceEdition>> GetAllEditionssAsync()
    {
        //var response = await _httpClient.GetAsync("events");
        //response.EnsureSuccessStatusCode();
        //var content = await response.Content.ReadAsStringAsync();
        //return JsonSerializer.Deserialize<IEnumerable<Event>>(content);

        return await Task.FromResult(new List<ConferenceEdition>
        {
            new (1, 2025, ConferenceCity.Stockholm, CfpStage.Closed, true),
            new (2, 2025, ConferenceCity.Goteborg, CfpStage.SpeakersSelected)
        });
    }

    public async Task<ConferenceEdition?> GetConferenceEdition(string city, int year)
    {
        var editions = await GetAllEditionssAsync();
        return editions.FirstOrDefault(e => e.City.ToString().ToLower() == city.ToLower() && e.Year == year);
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