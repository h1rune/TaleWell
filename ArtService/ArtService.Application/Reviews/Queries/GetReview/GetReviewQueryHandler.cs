using ArtService.Application.Common.Exceptions;
using ArtService.Application.Interfaces;
using ArtService.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArtService.Application.Reviews.Queries.GetReview
{
    public class GetReviewQueryHandler(IArtServiceDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetReviewQuery, ReviewVm>
    {
        private readonly IArtServiceDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<ReviewVm> Handle(GetReviewQuery request, CancellationToken cancellationToken)
        {
            var reviewEntity = await _dbContext.Reviews
                .FirstOrDefaultAsync(review => review.Id == request.ReviewId, cancellationToken)
                ?? throw new NotFoundException(nameof(Review), request.ReviewId);

            return _mapper.Map<ReviewVm>(reviewEntity);
        }
    }
}
