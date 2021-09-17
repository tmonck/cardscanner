using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AndroidX.Camera.Core;

using Java.Nio;

using Microsoft.Maui.Graphics;

namespace TestTcgScanner.Views.CameraView.Platforms.Android
{
    internal class FrameAnalyzer : Java.Lang.Object, ImageAnalysis.IAnalyzer
    {
        private readonly Action<ByteBuffer, Size> frameCallback;

        public FrameAnalyzer(Action<ByteBuffer, Size> callback)
        {
            frameCallback = callback;
        }

        public void Analyze(IImageProxy image)
        {
            var buffer = image.GetPlanes()[0].Buffer;

            var s = new Size(image.Width, image.Height);

            frameCallback?.Invoke(buffer, s);

            image.Close();
        }
    }
}
