using ArtService.Application.Common.Mappings;
using ArtService.Application.Reviews.Commands.CreateReview;
using ArtService.Domain.Common;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.ReviewModels
{
    public class CreateReviewDto : IMapWith<CreateReviewCommand>
    {
        [SwaggerSchema("ID of literary work for review")]
        public Guid WorkId { get; set; }

        [SwaggerSchema("Review's mark as a reaction")]
        public ReactionType Mark { get; set; }

        [SwaggerSchema("Review's text")]
        public required string Text { get; set; }
    }
}
