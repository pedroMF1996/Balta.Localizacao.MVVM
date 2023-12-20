using Balta.Localizacao.MVVM.Data.Repositorios;
using Balta.Localizacao.MVVM.Domain.Interfaces;
using Balta.Localizacao.MVVM.PresentetionLayer.Services;

namespace Balta.Localizacao.MVVM.PresentetionLayer.Configurations
{
	public static class DependenciesInjectionsConfigurations
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<IIbgeRepository, IbgeRepository>();
			services.AddScoped<IbgeService>();	
		}
	}
}
