using ArtService.Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Common.Validators
{
    public class OriginalWorkIdValidator<T> : AbstractValidator<T> where T : IHasOriginalWorkId
    {
        private readonly IArtServiceDbContext _dbContext;

        public OriginalWorkIdValidator(IArtServiceDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(command => command.OriginalWorkId)
                .MustAsync(IsOriginalIdValid)
                .WithMessage("OriginalWorkId can be specified only for fanfics and must exist.");
        }

        private async Task<bool> IsOriginalIdValid(T command, Guid? originalWorkId, CancellationToken cancellationToken)
        {
            bool isEmpty = originalWorkId is null;

            if (command.IsFanfic == false)
            {
                return isEmpty;
            }

            if (isEmpty)
            {
                return false;
            }

            return await _dbContext.Works
                .AnyAsync(work => work.Id == originalWorkId, cancellationToken);
        }
    }
}
