using Application.gSheets.Commands;
using Contracts.gSheet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Endpoints.Delete;

public static class DeleteCellEndpoint
{
    public static void MapDeleteCellEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/delte", async(
            [FromBody] DeleteCellRequest request,
            ISender sender) =>
        {
            await sender.Send(new DeleteCellCommand(request));
            return Results.Ok("Cell deleted from Google Sheet.");
        });
    }
}