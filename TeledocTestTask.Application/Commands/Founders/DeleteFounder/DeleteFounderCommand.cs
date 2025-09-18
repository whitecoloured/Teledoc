using MediatR;

namespace TeledocTestTask.Application.Commands.Founders.DeleteFounder
{
    public record DeleteFounderCommand(Guid Id) : IRequest<Unit>;
}
