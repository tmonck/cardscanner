using System;
using Java.Text;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Refit;
using TestTcgScanner.Models;
using TestTcgScanner.Services;

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
                .ConfigureMauiHandlers(handlers =>
                {

                    // Register just one handler for the control you need
                    handlers.AddCompatibilityRenderers(typeof(Xamarin.CommunityToolkit.UI.Views.MediaElementRenderer).Assembly);

                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton(RestService.For<IMtgApi>("https://api.magicthegathering.io/v1", new RefitSettings()
                    {
                        ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings()
                        {
                            Formatting = Formatting.Indented,
                            MissingMemberHandling = MissingMemberHandling.Ignore,
                            NullValueHandling = NullValueHandling.Ignore,
                            StringEscapeHandling = StringEscapeHandling.EscapeHtml
                        })
                    }));
                    services.AddSingleton<MtgApiService>();
                });
        }
    }
}