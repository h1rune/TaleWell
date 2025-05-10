using FluentValidation;

namespace ArtService.Application.Works.Commands.DeleteWork
{
    public class DeleteWorkCommandValidator : AbstractValidator<DeleteWorkCommand>
    {
        public DeleteWorkCommandValidator()
        {
            RuleFor(command => command.WorkId)
                .NotEmpty();

            RuleFor(command => command.UserId)
                .NotEmpty();
        }
    }
}
