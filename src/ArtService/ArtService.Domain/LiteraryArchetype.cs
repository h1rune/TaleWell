using ArtService.Domain.Common.ArchetypeParameters;

namespace ArtService.Domain
{
    public class LiteraryArchetype
    {
        public required string Id { get; set; }
        public required string Name { get; set; }

        public ScopeType ScopeType { get; set; }
        public NarrativeType NarrativeType { get; set; }
        public ToneType ToneType { get; set; }
        public PurposeType PurposeType { get; set; }

        public ICollection<Work> Works { get; set; } = [];
    }
}
