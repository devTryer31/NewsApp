using System;

namespace News.Application.Common.Mappings
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class MapWithAttribute : Attribute
    {
        public Type MapSourceType { get; set; }

        public MapWithAttribute() { }
        public MapWithAttribute(Type mapWithType) => MapSourceType = mapWithType;
    }
}
