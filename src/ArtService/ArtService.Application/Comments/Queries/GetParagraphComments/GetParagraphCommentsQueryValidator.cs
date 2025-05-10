using FluentValidation;

namespace ArtService.Application.Comments.Queries.GetParagraphComments
{
    public class GetParagraphCommentsQueryValidator 
        : AbstractValidator<GetParagraphCommentsQuery>
    {
        public GetParagraphCommentsQueryValidator()
        {
            RuleFor(query => query.ParagraphId)
                .NotEmpty();

            RuleFor(query => query.Offset)
                .GreaterThanOrEqualTo(0);

            RuleFor(query => query.Limit)
                .GreaterThan(0);
        }
    }
}
