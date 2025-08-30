using Contracts.gSheet;

namespace Application.Interfaces;

public interface IGoogleSheetService
{
    Task<IList<IList<object>>> ReadSheetAsync(string range);
    Task AppendValueToColumnAAsync(PostRequest request);
    Task DeleteCellAsync(DeleteCellRequest request);
}