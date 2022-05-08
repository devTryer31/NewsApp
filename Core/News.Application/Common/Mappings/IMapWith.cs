using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace News.Application.Common.Mappings
{
    public interface IMapWith<T>
    {
        void CreateMapping(Profile profile) => profile.CreateMap(typeof(T), GetType());//TODO: check for error.
    }
}
