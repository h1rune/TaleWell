using ArtService.Application.Interfaces;
using ArtService.Domain.Common;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Common.Validators
{
    public static class CustomDomainEntityValidator
    {
        public static IRuleBuilderOptions<T, Guid> MustExistInDb<T, TEntity>(
            this IRuleBuilder<T, Guid> ruleBuilder,
            IArtServiceDbContext dbContext)
            where TEntity : class, IDomainEntity
        {
            return ruleBuilder
                .MustAsync((id, cancellationToken) =>
                    dbContext.Set<TEntity>().AnyAsync(entity => entity.Id == id, cancellationToken))
                .WithMessage($"Entity '{typeof(TEntity).Name}' with the given ID does not exist.");
        }

        public static IRuleBuilderOptions<T, T> MustHaveAccess<T, TEntity>(
            this IRuleBuilder<T, T> ruleBuilder,
            IArtServiceDbContext dbContext,
            Func<T, Guid> getEntityId,
            Func<T, Guid> getAccountId)
            where TEntity : class, IDomainEntity
        {
            return ruleBuilder
                .MustAsync((command, cancellationToken) =>
                    dbContext.Set<TEntity>().AnyAsync(entity => entity.Id == getEntityId(command)
                        && entity.OwnerId == getAccountId(command), cancellationToken))
                .WithMessage($"No access to entity '{typeof(TEntity).Name}' by the given ID.");
        }
    }
}
