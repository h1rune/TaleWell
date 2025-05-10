namespace ArtService.Domain.Common
{
    public interface IDomainEntity
    {
        Guid Id { get; set; }
        Guid OwnerId { get; set; }
    }
}
