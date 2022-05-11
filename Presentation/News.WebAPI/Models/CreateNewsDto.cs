using News.Application.Common.Mappings;
using News.Application.News.Commands.Create;

namespace News.WebAPI.Models
{
    [MapWith(MapSourceType = typeof(CreateNewsCommandRequest))]
    public class CreateNewsDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
