using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Works.Commands.DeleteWork
{
    public class DeleteWorkCommandHandler(IArtServiceDbContext dbContext)
        : IRequestHandler<DeleteWorkCommand, Unit>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteWorkCommand request, CancellationToken cancellationToken)
        {
            var work = await _dbContext.Works
                .FirstOrDefaultAsync(work => work.Id == request.WorkId
                    && work.OwnerId == request.UserId, cancellationToken)
                ?? throw new NotFoundException(nameof(Work), request.WorkId);

            _dbContext.Works.Remove(work);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
