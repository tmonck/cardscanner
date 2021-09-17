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
using TestTcgScanner.Extensions;
using TestTcgScanner.Views.CameraView;

namespace TestTcgScanner
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var appBuilder = MauiApp.CreateBuilder();
            appBuilder
                .UseMauiApp<App>()
                .UseCardReader<CardReader>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            appBuilder.Services.AddSingleton(RestService.For<IMtgApi>("https://api.magicthegathering.io/v1", new RefitSettings()
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    StringEscapeHandling = StringEscapeHandling.EscapeHtml
                })
            }));
            appBuilder.Services.AddSingleton<MtgApiService>();

            return appBuilder.Build();
        }
    }
}