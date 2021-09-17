using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTcgScanner.Helpers;
using TestTcgScanner.Models;

namespace TestTcgScanner.Views.CameraView
{
    public interface ICardReader
    {
        CardReaderOptions Options { get; set; }
        CardDetectionResult Detect(PixelBufferHolder image);
    }
}
