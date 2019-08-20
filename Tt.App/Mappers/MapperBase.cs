using AutoMapper;

namespace Tt.App.Mappers
{
    public abstract class MapperBase
    {
        protected readonly IMapper mapper;

        public MapperBase(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
