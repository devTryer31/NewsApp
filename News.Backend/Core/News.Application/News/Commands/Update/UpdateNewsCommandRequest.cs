using System;

namespace News.Application.News.Commands.Update
{
    public class UpdateNewsCommandRequest : MediatR.IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
