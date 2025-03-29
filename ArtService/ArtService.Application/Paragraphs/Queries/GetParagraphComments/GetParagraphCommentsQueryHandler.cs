using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Paragraphs.Queries.GetParagraphComments
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
                .OrderBy(comment => comment.CreatedAt)
                .Skip(request.Offset)
                .Take(request.Limit)
                .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
                ?? throw new NotFoundException(nameof(Paragraph), request.ParagraphId);

            return new ParagraphCommentsVm { Comments = commentsQuery };
        }
    }
}
