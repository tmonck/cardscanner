using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTcgScanner.Models
{
    public record CardReaderOptions
    {
        public bool AutoRotate { get; set; }
        public bool TryHarder { get; set; }
    }
}
