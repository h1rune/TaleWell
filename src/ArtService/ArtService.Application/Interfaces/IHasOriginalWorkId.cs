namespace ArtService.Application.Interfaces
{
    public interface IHasOriginalWorkId
    {
        Guid? OriginalWorkId { get; }
        bool IsFanfic { get; }
    }
}
