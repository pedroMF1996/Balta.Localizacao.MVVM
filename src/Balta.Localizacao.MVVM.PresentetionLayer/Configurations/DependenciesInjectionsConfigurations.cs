using Balta.Localizacao.MVVM.PresentetionLayer.Services;

namespace Balta.Localizacao.MVVM.PresentetionLayer.Configurations
{
	public static class DependenciesInjectionsConfigurations
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<AutenticacaoService>();
		}
	}
}
