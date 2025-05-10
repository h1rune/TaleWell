namespace ArtService.Domain.Common
{
    public interface IHasRelatedAccess
    {
        IDomainEntity ParentEntity { get; }
    }
}
