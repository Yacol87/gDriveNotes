namespace Endpoints.Post;

using Application.gSheets.Commands;
using Contracts.gSheet;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public static class AppendEndpoint
{
    public static void MapAppendEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/append", async (
            [FromBody] PostRequest request,
            ISender sender) =>
        {
            await sender.Send(new AppendValueCommand(request));
            return Results.Ok("Value added to Google Sheet.");
        });
    }
}

