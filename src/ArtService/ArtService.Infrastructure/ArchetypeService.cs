using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using ArtService.Domain.Common.ArchetypeParameters;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Infrastructure
{
    public class ArchetypeService(IArtServiceDbContext dbContext) : IArchetypeService
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;

        public async Task<string> GetArchetypeIdByTagsAsync(LiteraryTag[] tags, CancellationToken cancellationToken)
        {
            int half = tags.Length / 2;
            int scopeCount = 0, narrativeCount = 0, toneCount = 0, purposeCount = 0;
            foreach (var tag in tags)
            {
                scopeCount += (int)tag.ScopeType;
                narrativeCount += (int)tag.NarrativeType;
                toneCount += (int)tag.ToneType;
                purposeCount += (int)tag.PurposeType;
            }

            var scopeType = scopeCount >= half ? ScopeType.Realism : ScopeType.Fiction;
            var narrativeType = narrativeCount >= half ? NarrativeType.BehaviorDynamic : NarrativeType.HumanOriented;
            var toneType = toneCount >= half ? ToneType.Serious : ToneType.Light;
            var purposeType = purposeCount >= half ? PurposeType.Illumination : PurposeType.Entertainment;

            var archetype = await _dbContext.LiteraryArchetypes
                .FirstOrDefaultAsync(archetype => archetype.ScopeType == scopeType
                    && archetype.NarrativeType == narrativeType 
                    && archetype.ToneType == toneType
                    && archetype.PurposeType == purposeType, 
                    cancellationToken)
                ?? throw new NotFoundException(nameof(LiteraryArchetype), "by types");

            return archetype.Id;
        }
    }
}
