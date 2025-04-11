namespace ArtService.Application.Volumes.Queries.GetWorkVolumes
{
    public class VolumeLookupDto
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public string? Title { get; set; }
        public string? CoverUrl { get; set; }
    }
}
