using ArtService.Application.Common.Validators;
using ArtService.Application.Interfaces;
using FluentValidation;

namespace ArtService.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidator(IArtServiceDbContext dbContext)
        {
            Include(new WorkExistsValidator<CreateReviewCommand>(dbContext));
            RuleFor(command => command.UserId).NotEmpty()
                .WithMessage("UserId must not be empty.");
            RuleFor(command => command.Mark).NotEmpty()
                .WithMessage("Mark must not be empty.");
            RuleFor(command => command.Text)
                .NotEmpty().WithMessage("Review's text must not be empty.")
                .MaximumLength(3000).WithMessage("Review's text has maximum 3000 characters.");
        }
    }
}
