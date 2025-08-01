using Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Set config values manually for demo purposes
string credentialsFilePath = "local-disk-465710-p4-7862ec4eb80b.json"; // Put this in secrets later
string spreadsheetId = "1w_ARyoN-IPqfNy0PPHCcYFfRaAQQzeyPZ5oZ4NrLHU0";

// Register GoogleSheetService
builder.Services.AddScoped<IGoogleSheetService>(sp =>
    new GoogleSheetService(credentialsFilePath, spreadsheetId));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();



// Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", async (IGoogleSheetService googleSheets) =>
{
    var values = await googleSheets.ReadSheetAsync("Sheet1!A1:C5");
    Console.Write(values);

    return Results.Ok(values);
});
app.Run();
