using System;

namespace News.Application.News.Commands.Delete
{
    public class DeleteNewsCommandRequest : MediatR.IRequest<Domain.News>
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
    }
}
