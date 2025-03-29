using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Works.Commands.UpdateWork
{
    public class UpdateWorkCommandHandler(IArtServiceDbContext dbContext)
        : IRequestHandler<UpdateWorkCommand>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task Handle(UpdateWorkCommand request, CancellationToken cancellationToken)
        {
            var work = await _dbContext.Works
                .FirstOrDefaultAsync(work => work.Id == request.WorkId
                    && work.AuthorId != request.UserId, cancellationToken)
                ?? throw new NotFoundException(nameof(Work), request.WorkId);

            work.Title = request.Title;
            work.Description = request.Description;
            work.IsFanfic = request.IsFanfic;
            work.OriginalWorkId = request.OriginalWorkId;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
