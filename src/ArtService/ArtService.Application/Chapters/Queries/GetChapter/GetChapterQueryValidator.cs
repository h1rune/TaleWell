using FluentValidation;

namespace ArtService.Application.Chapters.Queries.GetChapter
{
    public class GetChapterQueryValidator : AbstractValidator<GetChapterQuery>
    {
        public GetChapterQueryValidator()
        {
            RuleFor(command => command.ChapterId)
                .NotEmpty();
        }
    }
}
