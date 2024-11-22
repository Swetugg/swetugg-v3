using ConferenceManager.Services.Models;

namespace ConferenceManager.Services;

public class ConferenceService
{
    // TODO: Make this realistic data
    public async Task<IEnumerable<ConferenceEdition>> GetAllEditionssAsync()
    {
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
}