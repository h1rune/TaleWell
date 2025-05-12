using ArtService.Domain;

namespace ArtService.Application.Interfaces
{
    public interface IArchetypeService
    {
        Task<string> GetArchetypeIdByTagsAsync(LiteraryTag[] tags, CancellationToken cancellationToken);
    }
}
