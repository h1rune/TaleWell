using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;

namespace ArtService.Application.Works.Commands.CreateWork
{
    public class CreateWorkCommandHandler(IArtServiceDbContext dbContext)
        : IRequestHandler<CreateWorkCommand, Guid>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateWorkCommand request, CancellationToken cancellationToken)
        {
            var work = new Work
            {
                Id = Guid.NewGuid(),
                OwnerId = request.UserId,
                Title = request.Title,
                Description = request.Description,
                IsFanfic = request.IsFanfic,
                OriginalWorkId = request.OriginalWorkId,
                CreatedAt = DateTime.UtcNow
            };

            await _dbContext.Works.AddAsync(work, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return work.Id;
        }
    }
}
