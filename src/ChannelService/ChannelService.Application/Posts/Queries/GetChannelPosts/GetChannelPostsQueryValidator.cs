using FluentValidation;

namespace ChannelService.Application.Posts.Queries.GetChannelPosts
{
    public class GetChannelPostsQueryValidator : AbstractValidator<GetChannelPostsQuery>
    {
        public GetChannelPostsQueryValidator()
        {
            RuleFor(query => query.ActorId)
                .NotEmpty().WithMessage("Actor ID must be not empty.");
            RuleFor(query => query.ChannelHandle)
                .NotEmpty().WithMessage("Channel @handle must be not empty.");
            RuleFor(query => query.Offset)
                .GreaterThanOrEqualTo(0).WithMessage("Offset must be greater or equal to zero.");
            RuleFor(query => query.Limit)
                .GreaterThan(0).WithMessage("Offset must be greater than zero.");
        }
    }
}
