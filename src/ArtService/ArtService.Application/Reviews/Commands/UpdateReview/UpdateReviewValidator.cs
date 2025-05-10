using FluentValidation;

namespace ArtService.Application.Reviews.Commands.UpdateReview
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(command => command.UserId)
                .NotEmpty();
            RuleFor(command => command.ReviewId)
                .NotEmpty();
            RuleFor(command => command.Mark)
                .IsInEnum();
            RuleFor(command => command.Text)
                .NotEmpty()
                .MaximumLength(3000);
        }
    }
}
