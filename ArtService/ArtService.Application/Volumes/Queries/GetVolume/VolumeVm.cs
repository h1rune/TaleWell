namespace ArtService.Application.Volumes.Queries.GetVolume
{
    public class VolumeVm
    {
        public Guid WorkId { get; set; }
        public int Order { get; set; }
        public string? Title { get; set; }
        public string? CoverUrl { get; set; }
    }
}
