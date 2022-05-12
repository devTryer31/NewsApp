using System;

namespace News.Application.News.Queries.GetDetails
{
    public class GetNewsDetailsRequest : MediatR.IRequest<NewsDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
