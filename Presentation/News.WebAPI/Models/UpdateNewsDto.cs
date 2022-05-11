using News.Application.Common.Mappings;
using News.Application.News.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.WebAPI.Models
{
    [MapWith(MapSourceType = typeof(UpdateNewsCommandRequest))]
    public class UpdateNewsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
