using ArtService.Application.Common.Validators;
using ArtService.Application.Interfaces;
using FluentValidation;

namespace ArtService.Application.Works.Commands.CreateWork
{
    public class CreateWorkCommandValidator : AbstractValidator<CreateWorkCommand>
    {
        public CreateWorkCommandValidator(IArtServiceDbContext dbContext)
        {
            Include(new OriginalWorkIdValidator<CreateWorkCommand>(dbContext));
            RuleFor(command => command.UserId).NotEmpty()
                .WithMessage("UserId must not be empty.");
            RuleFor(command => command.Title).NotEmpty()
                .WithMessage("Title must not be empty.");
            RuleFor(command => command.Description).MaximumLength(1000)
                .WithMessage("Description must be less than 1000 characters.");
        }
    }
}
