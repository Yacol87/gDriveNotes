using Contracts.gSheet;
using MediatR;

namespace Application.gSheets.Commands
{
    public record AppendValueCommand(PostRequest Request) : IRequest<Unit>;
}
