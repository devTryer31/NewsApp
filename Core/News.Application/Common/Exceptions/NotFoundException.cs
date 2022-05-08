using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityTitle, object key) 
            : base($"Entity \'{entityTitle}\' with key ({key}) not found") { }
    }
}
