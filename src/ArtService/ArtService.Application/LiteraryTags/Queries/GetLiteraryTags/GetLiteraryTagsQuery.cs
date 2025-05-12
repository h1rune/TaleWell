using MediatR;

namespace ArtService.Application.LiteraryTags.Queries.GetLiteraryTags
{
    public class GetLiteraryTagsQuery
        : IRequest<LiteraryTagsVm>
    {
    }
}
