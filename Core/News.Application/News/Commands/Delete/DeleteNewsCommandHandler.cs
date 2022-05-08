using News.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace News.Application.News.Commands.Delete
{
    public class DeleteNewsCommandHandler : MediatR.IRequestHandler<DeleteNewsCommandRequest, Domain.News>
    {
        private readonly INewsDbContext _newsDb;

        public DeleteNewsCommandHandler(INewsDbContext newsDb) => _newsDb = newsDb;
        public async Task<Domain.News> Handle(DeleteNewsCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _newsDb.News.FindAsync(new[] { request.Id }, cancellationToken);

            if (entity is null || entity.UserId != request.UserId)
                throw new Common.Exceptions.NotFoundException(nameof(Domain.News), request.Id);


            _newsDb.News.Remove(entity);
            await _newsDb.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
