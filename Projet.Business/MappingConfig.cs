using AutoMapper;
using Projet.Business.Mapping;

namespace Projet.Business
{
    public class MappingConfig
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MappingProfile>();
			});
			return config.CreateMapper();
		});

		public static IMapper Mapper => Lazy.Value;
	}
}
