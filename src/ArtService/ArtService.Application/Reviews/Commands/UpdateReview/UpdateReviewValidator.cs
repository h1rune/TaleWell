using FluentValidation;

namespace ArtService.Application.Reviews.Commands.UpdateReview
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(command => command.UserId).NotEmpty()
                .WithMessage("UserId must not be empty.");
            RuleFor(command => command.ReviewId).NotEmpty()
                .WithMessage("ReviewId must not be empty.");
            RuleFor(command => command.Mark).NotEmpty()
                .WithMessage("Mark must not be empty.");
            RuleFor(command => command.Text)
                .NotEmpty().WithMessage("Review's text must not be empty.")
                .MaximumLength(3000).WithMessage("Review's text has maximum 3000 characters.");
        }
    }
}
