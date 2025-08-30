using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Application.Interfaces;
using Contracts.gSheet;

public class GoogleSheetService : IGoogleSheetService
{
    private readonly SheetsService _sheetsService;
    private readonly string _spreadsheetId;

    public GoogleSheetService(string spreadsheetId)
    {
        _spreadsheetId = spreadsheetId;
        var credential = GoogleCredential.GetApplicationDefault()
            .CreateScoped(SheetsService.Scope.Spreadsheets);

        _sheetsService = new SheetsService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = "YacolgDriveNotesApp",
        });
    }

    public async Task<IList<IList<object>>> ReadSheetAsync(string range)
    {
        var request = _sheetsService.Spreadsheets.Values.Get(_spreadsheetId, range);
        var response = await request.ExecuteAsync();
        return response.Values;
    }

    public async Task AppendValueToColumnAAsync(PostRequest request)
    {
        var values = await ReadSheetAsync("A:A");

        int firstEmptyRow = 1;
        if (values != null)
        {
            for (int i = 1; i < values.Count; i++)
            {
                if (values[i] == null || values[i].Count == 0 || string.IsNullOrWhiteSpace(values[i][0]?.ToString()))
                {
                    firstEmptyRow = i + 1;
                    break;
                }
                firstEmptyRow = values.Count + 1;
            }
        }

        var range = $"A{firstEmptyRow}";
        var valueRange = new ValueRange
        {
            Values = new List<IList<object>> { new List<object> { request.Value } }
        };

        var updateRequest = _sheetsService.Spreadsheets.Values.Update(valueRange, _spreadsheetId, range);
        updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
        await updateRequest.ExecuteAsync();
    }

    public async Task DeleteCellAsync(DeleteCellRequest request)
    {
        var range = $"{request.CellId}:{request.CellId}"; // e.g., "A1:A1"
        var clearValuesRequest = new ClearValuesRequest();
        await _sheetsService.Spreadsheets.Values.Clear(clearValuesRequest, _spreadsheetId, range).ExecuteAsync();
    }
}
