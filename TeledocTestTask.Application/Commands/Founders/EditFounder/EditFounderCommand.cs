using MediatR;

namespace TeledocTestTask.Application.Commands.Founders.EditFounder
{
    public record EditFounderCommand(EditFounderModel EditModel, Guid FounderId) : IRequest<Unit>;
}
