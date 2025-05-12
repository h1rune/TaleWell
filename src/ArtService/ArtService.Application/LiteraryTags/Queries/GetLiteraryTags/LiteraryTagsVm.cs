namespace ArtService.Application.LiteraryTags.Queries.GetLiteraryTags
{
    public class LiteraryTagsVm
    {
        public ICollection<LiteraryTagLookupDto> LiteraryTags { get; set; } = [];
    }
}
