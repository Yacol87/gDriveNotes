namespace Application.Interfaces;

public interface IGoogleSheetService
{
    Task<IList<IList<object>>> ReadSheetAsync(string range);
}