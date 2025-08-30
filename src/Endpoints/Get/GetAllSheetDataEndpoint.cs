using Application.gSheets.Queries;
using MediatR;

namespace Endpoints.Get;
public static class GetAllSheetDataEndpoint

{
    public static void MapGetAllSheetDataEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/sheet", async (ISender sender) =>
        {
            var data = await sender.Send(new GetAllSheetDataQuery());
            return Results.Ok(data);
        });
    }
}