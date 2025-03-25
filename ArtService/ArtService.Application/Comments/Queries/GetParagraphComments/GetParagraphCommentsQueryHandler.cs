using ArtService.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Comments.Queries.GetParagraphComments
{
    public class GetParagraphCommentsQueryHandler(IArtServiceDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetParagraphCommentsQuery, ParagraphCommentsVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<ParagraphCommentsVm> Handle(GetParagraphCommentsQuery request, CancellationToken cancellationToken)
        {
            var commentsQuery = await _dbContext.Comments
                .Where(comment => comment.ParagraphId == request.ParagraphId)
                .ProjectTo<CommentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ParagraphCommentsVm { Comments = commentsQuery };
        }
    }
}
