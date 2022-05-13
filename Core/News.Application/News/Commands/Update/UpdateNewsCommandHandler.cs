using MediatR;
using News.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace News.Application.News.Commands.Update
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommandRequest>
    {
        private readonly INewsDbContext _newsDb;

        public UpdateNewsCommandHandler(INewsDbContext newsDb) => _newsDb = newsDb;

        public async Task<Unit> Handle(UpdateNewsCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _newsDb.News.FindAsync(new[] { request.Id }, cancellationToken);

            if (entity is null || request.UserId != entity.UserId)
                throw new Common.Exceptions.NotFoundException(nameof(Domain.News), request.Id);

            entity.Title = request.Title;
            entity.Content = request.Content;
            entity.LastModifiedDate = DateTime.Now;

            await _newsDb.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
