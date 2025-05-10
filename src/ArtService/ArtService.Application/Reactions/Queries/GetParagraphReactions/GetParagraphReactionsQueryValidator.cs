using FluentValidation;

namespace ArtService.Application.Reactions.Queries.GetParagraphReactions
{
    public class GetParagraphReactionsQueryValidator
         : AbstractValidator<GetParagraphReactionsQuery>
    {
        public GetParagraphReactionsQueryValidator()
        {
            RuleFor(query => query.UserId)
                .NotEmpty();

            RuleFor(query => query.ParagraphId)
                .NotEmpty();
        }
    }
}
