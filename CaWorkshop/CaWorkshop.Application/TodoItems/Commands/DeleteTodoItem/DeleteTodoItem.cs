using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using CaWorkshop.Application.Common.Extensions;
using CaWorkshop.Application.Common.Interfaces;
using MediatR;

namespace CaWorkshop.Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommand : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteTodoItemCommandHandler
        : AsyncRequestHandler<DeleteTodoItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(DeleteTodoItemCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems.FindAsync(request.Id);

            Guard.Against.NotFound(entity, request.Id);

            _context.TodoItems.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
