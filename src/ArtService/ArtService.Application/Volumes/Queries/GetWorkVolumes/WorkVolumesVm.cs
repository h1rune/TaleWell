namespace ArtService.Application.Volumes.Queries.GetWorkVolumes
{
    public class WorkVolumesVm 
    {
        public IList<VolumeLookupDto> Volumes { get; set; } = null!;
    }
}
