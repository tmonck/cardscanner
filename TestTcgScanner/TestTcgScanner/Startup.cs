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
                .UseMicrosoftExtensionsServiceProviderFactory() // Apparently this is what's needed to call .AddHttpClient. Need to dig into why
                .ConfigureServices(services =>
                {
                    services.AddHttpClient("mtgApi", c =>
					{
						c.BaseAddress = new Uri("https://api.magicthegathering.io");
						c.DefaultRequestHeaders.Add("Accept", "application/json");
						c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
					});
                    services.AddScoped<ICardApi<MtgCard>, MtgCardApi>();
                });
        }
	}
}