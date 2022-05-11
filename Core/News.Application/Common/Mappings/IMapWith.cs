using AutoMapper;

namespace News.Application.Common.Mappings
{
    [System.Obsolete("This method is obsolete. Use MapToAttribute", false)]
    public interface IMapWith<T>
    {
        public void CreateMapping(Profile profile) 
            => profile.CreateMap(typeof(T), GetType());
    }
}
