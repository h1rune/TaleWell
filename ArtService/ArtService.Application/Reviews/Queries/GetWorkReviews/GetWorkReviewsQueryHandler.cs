using ArtService.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Reviews.Queries.GetWorkReviews
{
    public class GetWorkReviewsQueryHandler(IArtServiceDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetWorkReviewsQuery, WorkReviewsVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<WorkReviewsVm> Handle(GetWorkReviewsQuery request, CancellationToken cancellationToken)
        {
            var reviewsQuery = await _dbContext.Reviews
                .Where(review => review.WorkId == request.WorkId)
                .ProjectTo<ReviewLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new WorkReviewsVm { Reviews = reviewsQuery };
        }
    }
}
