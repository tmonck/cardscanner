﻿
using System;
using System.Collections.Generic;

namespace TestTcgScanner.Views.CameraView
{
    [Flags]
    public enum CameraMode
    {
        Preview = 0,
        Capture = 1,
        Analyze = 2
    }
}
