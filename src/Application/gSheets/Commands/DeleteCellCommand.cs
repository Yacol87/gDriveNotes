using Contracts.gSheet;
using MediatR;

namespace Application.gSheets.Commands
{
    public record DeleteCellCommand(DeleteCellRequest Request) : IRequest<Unit>;
}
