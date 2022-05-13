using AutoMapper;
using News.Application.Common.Exceptions;
using News.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace News.Application.News.Queries.GetDetails
{
    public class GetNewsDetailsHandler : MediatR.IRequestHandler<GetNewsDetailsRequest, NewsDetailsVm>
    {
        private readonly INewsDbContext _newsDb;
        private readonly IMapper _mapper;

        public GetNewsDetailsHandler(Interfaces.INewsDbContext newsDb, IMapper mapper)
        {
            _newsDb = newsDb;
            _mapper = mapper;
        }

        public async Task<NewsDetailsVm> Handle(GetNewsDetailsRequest request, CancellationToken cancellationToken)
        {
            var entity = await _newsDb.News.FindAsync(new[] { request.Id }, cancellationToken);

            if (entity is null || entity.UserId != request.UserId)
                throw new NotFoundException(nameof(Domain.News), request.Id);

            return _mapper.Map<NewsDetailsVm>(entity);
        }
    }
}
