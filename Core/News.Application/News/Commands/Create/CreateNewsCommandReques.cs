using MediatR;
using System;

namespace News.Application.News.Commands.Create
{
    public class CreateNewsCommandReques : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
