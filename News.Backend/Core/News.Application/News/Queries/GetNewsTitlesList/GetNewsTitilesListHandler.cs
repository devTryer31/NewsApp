using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using News.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace News.Application.News.Queries.GetNewsTitlesList
{
    public class GetNewsTitilesListHandler : MediatR.IRequestHandler<GetNewsTitilesListRequest, NewsTitlesListVm>
    {
        private readonly INewsDbContext _newsDb;
        private readonly IMapper _mapper;

        public GetNewsTitilesListHandler(INewsDbContext newsDb, IMapper mapper)
        {
            _newsDb = newsDb;
            _mapper = mapper;
        }

        public async Task<NewsTitlesListVm> Handle(GetNewsTitilesListRequest request, CancellationToken cancellationToken)
        {
            var entities = await _newsDb.News.Where(n => n.UserId == request.UserId).ProjectTo<NewsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return new NewsTitlesListVm { NewsCollection = entities };
        }
    }
}
