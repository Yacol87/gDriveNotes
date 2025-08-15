using Application.Interfaces;
using MediatR;

namespace Application.gSheets.Commands;

public class AppendValueCommandHandler : IRequestHandler<AppendValueCommand, Unit>
{
    private readonly IGoogleSheetService _googleSheetService;
    public AppendValueCommandHandler(IGoogleSheetService googleSheetService)
    {
        _googleSheetService = googleSheetService;
    }

    public async Task<Unit> Handle(AppendValueCommand request, CancellationToken ct)
    {
        await _googleSheetService.AppendValueToColumnAAsync(request.Request);
        return Unit.Value;
    }
}
