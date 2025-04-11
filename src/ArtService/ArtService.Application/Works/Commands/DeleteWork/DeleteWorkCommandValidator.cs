using FluentValidation;

namespace ArtService.Application.Works.Commands.DeleteWork
{
    public class DeleteWorkCommandValidator : AbstractValidator<DeleteWorkCommand>
    {
        public DeleteWorkCommandValidator()
        {
            RuleFor(command => command.WorkId).NotEmpty()
                .WithMessage("WorkId must not be empty.");
            RuleFor(command => command.UserId).NotEmpty()
                .WithMessage("UserId must not be empty.");
        }
    }
}
