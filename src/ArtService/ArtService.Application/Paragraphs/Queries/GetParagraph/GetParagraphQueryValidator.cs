using FluentValidation;

namespace ArtService.Application.Paragraphs.Queries.GetParagraph
{
    public class GetParagraphQueryValidator : AbstractValidator<GetParagraphQuery>
    {
        public GetParagraphQueryValidator()
        {
            RuleFor(query => query.ParagraphId)
                .NotEmpty();
        }
    }
}
