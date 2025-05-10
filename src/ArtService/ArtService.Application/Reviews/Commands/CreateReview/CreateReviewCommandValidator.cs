using ArtService.Application.Common.Validators;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using FluentValidation;

namespace ArtService.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidator(IArtServiceDbContext dbContext)
        {
            RuleFor(command => command.UserId)
                .NotEmpty();
            RuleFor(command => command.WorkId)
                .MustExistInDb<CreateReviewCommand, Work>(dbContext);
            RuleFor(command => command.Mark)
                .IsInEnum();
            RuleFor(command => command.Text)
                .NotEmpty()
                .MaximumLength(3000);
        }
    }
}
