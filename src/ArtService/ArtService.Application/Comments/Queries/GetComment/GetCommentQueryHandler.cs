using ArtService.Application.Comments.Queries.GetParagraph;
using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Comments.Queries.GetComment
{
    public class GetCommentQueryHandler(IArtServiceDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetCommentQuery, CommentVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CommentVm> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var commentEntity = await _dbContext.Comments
                .FirstOrDefaultAsync(comment => comment.Id == request.CommentId, cancellationToken)
                ?? throw new NotFoundException(nameof(Comment), request.CommentId);

            return _mapper.Map<CommentVm>(commentEntity);   
        }
    }
}
