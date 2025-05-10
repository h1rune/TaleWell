using ArtService.Application.Common.Mappings;
using ArtService.Application.Reviews.Commands.UpdateReview;
using ArtService.Domain.Common;
using Swashbuckle.AspNetCore.Annotations;

namespace ArtService.WebApi.Models.ReviewModels
{
    public class UpdateReviewDto : IMapWith<UpdateReviewCommand>
    {
        [SwaggerSchema("Review's mark as a reaction")] 
        public ReactionType Mark { get; set; }

        [SwaggerSchema("Review's text")]
        public required string Text { get; set; }
    }
}
