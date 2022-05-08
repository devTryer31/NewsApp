using System.Collections.Generic;

namespace News.Application.News.Queries.GetNewsTitlesList
{
    public class NewsTitlesListVm 
    {
        public IList<NewsLookupDto> NewsCollection { get; set; }
    }
}