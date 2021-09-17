
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestTcgScanner.Helpers;

namespace TestTcgScanner.Views.CameraView
{
    public class CameraFrameBufferEventArgs : EventArgs
    {
        public CameraFrameBufferEventArgs(PixelBufferHolder pixelBufferHolder) : base()
            => Data = pixelBufferHolder;

        public readonly PixelBufferHolder Data;
    }
}
