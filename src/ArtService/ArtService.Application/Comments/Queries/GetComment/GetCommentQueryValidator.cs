using FluentValidation;

namespace ArtService.Application.Comments.Queries.GetComment
{
    public class GetCommentQueryValidator : AbstractValidator<GetCommentQuery>
    {
        public GetCommentQueryValidator()
        {
            RuleFor(query => query.CommentId)
                .NotEmpty();
        }
    }
}
