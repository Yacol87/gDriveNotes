namespace Application.gSheets.Queries
{
    using Contracts.gSheet;
    using MediatR;
    using System.Collections.Generic;

    public class GetAllSheetDataQuery : IRequest<IList<SheetCellDto>>
    {

    }
}
