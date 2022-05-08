using News.Application.Common.Mappings;
using System;

namespace News.Application.News.Queries.GetNewsTitlesList
{
    public class NewsLookupDto : IMapWith<Domain.News>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
