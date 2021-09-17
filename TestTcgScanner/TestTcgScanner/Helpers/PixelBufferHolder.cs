using Microsoft.Maui.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTcgScanner.Helpers
{
	public record PixelBufferHolder
	{
		public Size Size { get; init; }

		public

#if ANDROID
		Java.Nio.ByteBuffer
#elif IOS || MACCATALYST
		CoreVideo.CVPixelBuffer
#else
		byte[]
#endif

		Data
		{ get; init; }
	}
}
