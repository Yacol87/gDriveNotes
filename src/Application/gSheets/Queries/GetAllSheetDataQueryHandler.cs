using Application.gSheets.Queries;
using Application.Interfaces;
using Contracts.gSheet;
using MediatR;

namespace Application.gSheets.Queries
{
    public  class GetAllSheetDataQueryHandler : IRequestHandler<GetAllSheetDataQuery, IList<SheetCellDto>>
    {
        private readonly IGoogleSheetService _googleSheetService;
        public GetAllSheetDataQueryHandler(IGoogleSheetService googleSheetService)
        {
            _googleSheetService = googleSheetService;
        }

        public async Task<IList<SheetCellDto>> Handle(GetAllSheetDataQuery request, CancellationToken cancellationToken)
        {
            var values = await _googleSheetService.ReadSheetAsync("A:A");
            var result = new List<SheetCellDto>();

            for (int row = 0; row < values.Count; row++)
            {
                var rowData = values[row];
                if (rowData.Count > 0)
                {
                    result.Add(new SheetCellDto
                    {
                        Concat = "A" + (row + 1),
                        Value = rowData[0]
                    });
                }
            }
            return result;
        }
    }
}