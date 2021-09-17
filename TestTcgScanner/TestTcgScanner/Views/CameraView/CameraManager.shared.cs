using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Maui.Graphics;
using Microsoft.Maui;

namespace TestTcgScanner.Views.CameraView
{
    public partial class CameraManager : IDisposable
    {
        public CameraManager(IMauiContext context, CameraLocation cameraLocation)
        {
            Context = context;
            CameraLocation = cameraLocation;
        }

        protected readonly IMauiContext Context;
        public event EventHandler<CameraFrameBufferEventArgs> FrameReady;

        public CameraLocation CameraLocation { get; private set; }

        public void UpdateCameraLocation(CameraLocation cameraLocation)
        {
            CameraLocation = cameraLocation;

            UpdateCamera();
        }

        public static async Task<bool> CheckPermissions()
            => (await Microsoft.Maui.Essentials.Permissions.RequestAsync<Microsoft.Maui.Essentials.Permissions.Camera>()) == Microsoft.Maui.Essentials.PermissionStatus.Granted;
    }
}
