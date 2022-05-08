using News.Application.Common.Mappings;
using System;

namespace News.Application.News.Queries.GetDetails
{
    public class NewsDetailsVm : IMapWith<Domain.News>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

    }
}
