using ArtService.Application.Common.Validators;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using FluentValidation;

namespace ArtService.Application.Works.Commands.UpdateWork
{
    public class UpdateWorkCommandValidator : AbstractValidator<UpdateWorkCommand>
    {
        public UpdateWorkCommandValidator(IArtServiceDbContext dbContext)
        {
            RuleFor(command => command.UserId)
                .NotEmpty();

            RuleFor(command => command.WorkId)
                .NotEmpty();

            RuleFor(command => command.OriginalWorkId)
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(command => command.OriginalWorkId!.Value)
                        .MustExistInDb<UpdateWorkCommand, Work>(dbContext);
                })
                .When(command => command.IsFanfic);

            RuleFor(command => command.Title)
                .NotEmpty();

            RuleFor(command => command.Description)
                .MaximumLength(1000);
        }
    }
}
