using MediatR;
using System;

namespace News.Application.News.Queries.GetNewsTitlesList
{
    public class GetNewsTitilesListRequest : IRequest<NewsTitlesListVm>
    {
        public Guid UserId { get; set; }
    }
}
