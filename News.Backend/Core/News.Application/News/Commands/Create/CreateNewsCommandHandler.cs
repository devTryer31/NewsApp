using News.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace News.Application.News.Commands.Create
{
    public class CreateNewsCommandHandler : MediatR.IRequestHandler<CreateNewsCommandRequest, Guid>
    {
        private readonly INewsDbContext newsDb;

        public CreateNewsCommandHandler(INewsDbContext newsDb) => this.newsDb = newsDb;

        public async Task<Guid> Handle(CreateNewsCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.News news = new()
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Title = request.Title,
                Content = request.Content,
                CreationDate = DateTime.UtcNow
            };

            await newsDb.News.AddAsync(news, cancellationToken);
            await newsDb.SaveChangesAsync(cancellationToken);

            return news.Id;
        }
    }
}
