using FluentValidation;

namespace ArtService.Application.Paragraphs.Queries.GetChapterParagraphs
{
    public class GetChapterParagraphsQueryValidator
        : AbstractValidator<GetChapterParagraphsQuery>
    {
        public GetChapterParagraphsQueryValidator()
        {
            RuleFor(query => query.ChapterId)
                .NotEmpty();

            RuleFor(query => query.Offset)
                .GreaterThanOrEqualTo(0);

            RuleFor(query => query.Limit)
                .GreaterThan(0);
        }
    }
}
