using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Works.Commands.UpdateWork
{
    public class UpdateWorkCommandHandler(IArtServiceDbContext dbContext, IArchetypeService archetypeService)
        : IRequestHandler<UpdateWorkCommand, Unit>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IArchetypeService _archetypeService = archetypeService;

        public async Task<Unit> Handle(UpdateWorkCommand request, CancellationToken cancellationToken)
        {
            var work = await _dbContext.Works
                .Include(work => work.LiteraryArchetype)
                .FirstOrDefaultAsync(work => work.Id == request.WorkId
                    && work.OwnerId == request.UserId, cancellationToken)
                ?? throw new NotFoundException(nameof(Work), request.WorkId);

            work.Title = request.Title;
            work.Description = request.Description;
            work.IsFanfic = request.IsFanfic;
            work.OriginalWorkId = request.OriginalWorkId;

            if (request.TagIds.Count != 0)
            {
                var tagList = await _dbContext.LiteraryTags
                    .Where(tag => request.TagIds.Contains(tag.Id))
                    .ToArrayAsync(cancellationToken);

                work.Tags = tagList;
                work.LiteraryArchetypeId = await _archetypeService
                    .GetArchetypeIdByTagsAsync(tagList, cancellationToken);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
