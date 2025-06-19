using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Works.Commands.CreateWork
{
    public class CreateWorkCommandHandler(IArtServiceDbContext dbContext, IArchetypeService archetypeService)
        : IRequestHandler<CreateWorkCommand, Guid>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IArchetypeService _archetypeService = archetypeService;

        public async Task<Guid> Handle(CreateWorkCommand request, CancellationToken cancellationToken)
        {
            var tagList = await _dbContext.LiteraryTags
                .Where(tag => request.TagIds.Contains(tag.Id))
                .ToArrayAsync(cancellationToken);

            var work = new Work
            {
                Id = Guid.NewGuid(),
                OwnerId = request.UserId,
                OwnerHandle = request.OwnerHandle,
                Title = request.Title,
                Description = request.Description,
                IsFanfic = request.IsFanfic,
                OriginalWorkId = request.OriginalWorkId,
                CreatedAt = DateTime.UtcNow,

                Tags = tagList,
                FormType = request.FormType,
                LiteraryArchetypeId = await _archetypeService
                    .GetArchetypeIdByTagsAsync(tagList, cancellationToken)
            };

            await _dbContext.Works.AddAsync(work, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return work.Id;
        }
    }
}
