using Endpoints.Delete;
using Endpoints.Get;
using Endpoints.Post;

namespace Endpoints;

public static class EndpointRegistrationExtensions
{
    public static void MapAllEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapAppendEndpoint();
        app.MapGetAllSheetDataEndpoint();
        app.MapDeleteCellEndpoint();
    }
}
