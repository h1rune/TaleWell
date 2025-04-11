using ArtService.Application.Common.Validators;
using ArtService.Application.Interfaces;
using FluentValidation;

namespace ArtService.Application.Works.Commands.UpdateWork
{
    public class UpdateWorkCommandValidator : AbstractValidator<UpdateWorkCommand>
    {
        public UpdateWorkCommandValidator(IArtServiceDbContext dbContext)
        {
            Include(new OriginalWorkIdValidator<UpdateWorkCommand>(dbContext));
            RuleFor(command => command.WorkId).NotEmpty()
                .WithMessage("WorkId must not be empty.");
            RuleFor(command => command.UserId).NotEmpty()
                .WithMessage("UserId must not be empty.");
            RuleFor(command => command.Title).NotEmpty()
                .WithMessage("Title must not be empty.");
            RuleFor(command => command.Description).MaximumLength(1000)
                .WithMessage("Description must be less than 1000 characters.");
        }
    }
}
