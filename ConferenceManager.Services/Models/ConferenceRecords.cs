namespace ConferenceManager.Services.Models;

public record ConferenceEdition(int Id, int Year, ConferenceCity City, CfpStage CfpStage, bool IsCurrent = false);