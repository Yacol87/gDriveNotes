using Application.Interfaces;
using MediatR;


namespace Application.gSheets.Commands;

public class DeleteCellCommandHandler : IRequestHandler<DeleteCellCommand, Unit>
{
    private readonly IGoogleSheetService _googleSheetService;
    public DeleteCellCommandHandler(IGoogleSheetService googleSheetService)
    {
        _googleSheetService = googleSheetService;
    }
    public async Task<Unit> Handle(DeleteCellCommand request, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(request.Request.CellId))
        {
            throw new ArgumentException("Heeey! CellId cannot be null or empty please provide value in excel format A2 or B7", nameof(request.Request.CellId));
        }
        try
        {
            await _googleSheetService.DeleteCellAsync(request.Request);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Some weird error occured, you better check it out :/ . I failed to delete cell from Google Sheet.", ex);
        }
        return Unit.Value;
    }
}
