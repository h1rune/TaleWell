using FluentValidation;

namespace ArtService.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandValidator : AbstractValidator<DeleteReviewCommand>
    {
        public DeleteReviewCommandValidator()
        {
            RuleFor(command => command.UserId)
                .NotEmpty();
            RuleFor(command => command.ReviewId)
                .NotEmpty();
        }
    }
}
