using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTcgScanner.Models
{
    public record CardDetectionResult
    {
        public byte[] Raw { get; set; }
        public MtgSearchParams DetectedItems { get; set; }
    }
}
