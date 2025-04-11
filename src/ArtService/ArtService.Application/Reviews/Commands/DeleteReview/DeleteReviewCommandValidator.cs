using FluentValidation;

namespace ArtService.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandValidator : AbstractValidator<DeleteReviewCommand>
    {
        public DeleteReviewCommandValidator()
        {
            RuleFor(command => command.UserId).NotEmpty()
                .WithMessage("UserId must not be empty.");
            RuleFor(command => command.ReviewId).NotEmpty()
                .WithMessage("ReviewId must not be empty.");
        }
    }
}
