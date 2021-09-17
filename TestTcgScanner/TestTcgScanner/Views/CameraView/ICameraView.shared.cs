using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace TestTcgScanner.Views.CameraView
{
    public interface ICameraFrameAnalyzer
    {
        event EventHandler<CameraFrameBufferEventArgs> FrameReady;
    }

    public interface ICameraView : IView, ICameraFrameAnalyzer
    {
        CameraLocation CameraLocation { get; set; }

        void AutoFocus();

        void Focus(Point point);

        bool IsTorchOn { get; set; }
    }
}
