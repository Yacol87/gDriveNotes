using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Application.Interfaces;

public class GoogleSheetService : IGoogleSheetService
{
    private readonly SheetsService _sheetsService;
    private readonly string _spreadsheetId;

    public GoogleSheetService(string credentialsFilePath, string spreadsheetId)
    {
        _spreadsheetId = spreadsheetId;
        GoogleCredential credential;
        using var stream = new FileStream(credentialsFilePath, FileMode.Open, FileAccess.Read);
        credential = GoogleCredential.FromStream(stream).CreateScoped(SheetsService.Scope.SpreadsheetsReadonly);

        _sheetsService = new SheetsService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = "MyApp",
        });
    }

    public async Task<IList<IList<object>>> ReadSheetAsync(string range)
    {
        var request = _sheetsService.Spreadsheets.Values.Get(_spreadsheetId, range);
        var response = await request.ExecuteAsync();
        return response.Values;
    }
}
