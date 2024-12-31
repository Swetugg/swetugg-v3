using ConferenceManager.Services.Models;

namespace ConferenceManager.Services;

public class ConferenceService
{
    // TODO: Make this realistic data
    public async Task<IEnumerable<ConferenceEdition>> GetAllEditionssAsync()
    {
        return await Task.FromResult(new List<ConferenceEdition>
        {
            new (1, 2024, ConferenceCity.Stockholm, CfpStage.Closed, "#A30046", new HeaderInfo("Blah di balh Stockholm", ""), true),
            new (2, 2025, ConferenceCity.Goteborg, CfpStage.SpeakersSelected, "#008266", new HeaderInfo("Blah di balh Goteborg", ""))
        });
    }

    public async Task<ConferenceEdition?> GetConferenceEditionAsync(string city, int year)
    {
        var editions = await GetAllEditionssAsync();
        return editions.FirstOrDefault(e => e.City.ToString().ToLower() == city.ToLower() && e.Year == year);
    }
}