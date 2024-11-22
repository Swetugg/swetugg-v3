namespace ConferenceManager.Services.Models;

public record ConferenceEdition(
    int Id, 
    int Year, 
    ConferenceCity City, 
    CfpStage CfpStage,
    string MainColor,
    HeaderInfo HeaderInfo,
    bool IsCurrent = false);

public record HeaderInfo(string text, string imageUrl);