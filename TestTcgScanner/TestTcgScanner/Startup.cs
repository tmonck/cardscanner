using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Extensions.DependencyInjection;

[assembly: XamlCompilationAttribute(XamlCompilationOptions.Compile)]

namespace TestTcgScanner
{
	public class Startup : IStartup
	{
		public void Configure(IAppHostBuilder appBuilder)
		{
			appBuilder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				})
				.UseMauiServiceProviderFactory(true)
				.ConfigureServices(services =>
				{
					services.AddScoped<ICardApi<MtgCard>, MtgCardApi>();
				});
		}
	}
}