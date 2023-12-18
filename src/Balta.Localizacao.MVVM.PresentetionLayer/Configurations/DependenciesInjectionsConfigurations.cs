using Balta.Localizacao.MVVM.PresentetionLayer.Services;
using Microsoft.AspNetCore.Identity;

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
