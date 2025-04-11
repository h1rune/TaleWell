using ArtService.Application.Comments.Queries.GetParagraph;
using MediatR;

namespace ArtService.Application.Comments.Queries.GetComment
{
    public class GetCommentQuery : IRequest<CommentVm>
    {
        public Guid CommentId { get; set; }
    }
}
