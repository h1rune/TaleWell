using ArtService.Application.Common.Validators;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using FluentValidation;

namespace ArtService.Application.Works.Commands.CreateWork
{
    public class CreateWorkCommandValidator : AbstractValidator<CreateWorkCommand>
    {
        public CreateWorkCommandValidator(IArtServiceDbContext dbContext)
        {
            RuleFor(command => command.UserId)
                .NotEmpty();

            RuleFor(command => command.OriginalWorkId)
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(command => command.OriginalWorkId!.Value)
                        .MustExistInDb<CreateWorkCommand, Work>(dbContext);
                })
                .When(command => command.IsFanfic);

            RuleFor(command => command.Title)
                .NotEmpty();

            RuleFor(command => command.Description)
                .MaximumLength(1000);
        }
    }
}
