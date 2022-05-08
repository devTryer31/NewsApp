using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using News.Application.Interfaces;

namespace News.Application.News.Commands.Create
{
    public class CreateNewsCommandHandler : MediatR.IRequestHandler<CreateNewsCommandReques, Guid>
    {
        private readonly INewsDbContext newsDb;

        public CreateNewsCommandHandler(INewsDbContext newsDb) => this.newsDb = newsDb;

        public async Task<Guid> Handle(CreateNewsCommandReques request, CancellationToken cancellationToken)
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
