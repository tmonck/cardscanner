using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTcgScanner.Models;

namespace TestTcgScanner.Views.CameraView
{
    public interface ICameraCardReaderView : ICameraView
    {
        CardReaderOptions Options { get; }

        event EventHandler<CardDetectionEventArgs> CardDetected;

        bool IsDetecting { get; set; }
    }
}
