using News.Application.Common.Mappings;
using System;

namespace News.Application.News.Queries.GetNewsTitlesList
{
    [MapWith(MapSourceType = typeof(Domain.News))]
    public class NewsLookupDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
