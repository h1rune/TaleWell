using ArtService.Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Common.Validators
{
    public class WorkExistsValidator<T> : AbstractValidator<T> where T : IHasWorkId
    {
        private readonly IArtServiceDbContext _dbContext;

        public WorkExistsValidator(IArtServiceDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(entity => entity.WorkId)
                .NotEmpty()
                .MustAsync(IsWorkExist)
                .WithMessage("Work must exist.");
        }

        private async Task<bool> IsWorkExist(Guid workId, CancellationToken cancellationToken)
        {
            return await _dbContext.Works
                .AnyAsync(work => work.Id == workId, cancellationToken);
        }
    }
}
