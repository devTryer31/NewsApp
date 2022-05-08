using System;

namespace News.Domain
{
    public class News
    {
        public Guid NewsId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public Guid User { get; set; }
    }
}
