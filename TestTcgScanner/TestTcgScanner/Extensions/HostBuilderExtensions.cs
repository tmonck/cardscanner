#if IOS || MACCATALYST
global using NativePlatformCameraPreviewView = global::UIKit.UIView;
global using NativePlatformView = global::UIKit.UIView;
global using NativePlatformImageView = global::UIKit.UIImageView;
global using NativePlatformImage = global::UIKit.UIImage;
#elif ANDROID
global using NativePlatformCameraPreviewView = global::AndroidX.Camera.View.PreviewView;
global using NativePlatformView = global::Android.Views.View;
global using NativePlatformImageView = global::Android.Widget.ImageView;
global using NativePlatformImage = global::Android.Graphics.Bitmap;
#endif

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;
using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTcgScanner.Views.CameraView;

namespace TestTcgScanner.Extensions
{
    public static class CameraViewExtensions
    {
        public static MauiAppBuilder UseCardReader(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler(typeof(ICameraView), typeof(CameraViewHandler));
                handlers.AddHandler(typeof(ICameraCardReaderView), typeof(CameraCardReaderViewHandler));
            });

            builder.Services.AddTransient<ICardReader, CardReader>();

            return builder;
        }

        public static MauiAppBuilder UseCardReader<TCardReader>(this MauiAppBuilder builder) where TCardReader : class, ICardReader
        {
            builder.ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler(typeof(ICameraView), typeof(CameraViewHandler));
                handlers.AddHandler(typeof(ICameraCardReaderView), typeof(CameraCardReaderViewHandler));
            });

            builder.Services.AddTransient<ICardReader, TCardReader>();

            return builder;
        }

    }
}