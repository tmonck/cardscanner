using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTcgScanner.Models;

namespace TestTcgScanner.Views.CameraView
{
    public class CardDetectionEventArgs : EventArgs
    {
        public CardDetectionEventArgs(CardDetectionResult results)
            : base()
        {
            Results = results;
        }

        public CardDetectionResult Results { get; private set; }
    }
}
