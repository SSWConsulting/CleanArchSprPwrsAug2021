using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using CaWorkshop.Application.Common.Extensions;
using CaWorkshop.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CaWorkshop.Application.TodoLists.Commands.DeleteTodoList
{
    public class DeleteTodoListCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTodoListCommandHandler
        : AsyncRequestHandler<DeleteTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoLists
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            Guard.Against.NotFound(entity, request.Id);

            _context.TodoLists.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
