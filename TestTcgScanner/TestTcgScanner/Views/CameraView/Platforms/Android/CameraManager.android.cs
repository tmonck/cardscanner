using System;
using Android.Content;
using Android.Graphics;
using Android.Hardware.Camera2;
using Android.Hardware.Camera2.Params;
using Android.Media;
using Android.Nfc;
using Android.OS;
using Android.Renderscripts;
using Android.Runtime;
using Android.Util;
using Android.Views;
using AndroidX.Camera.Core;
using AndroidX.Camera.View;
using AndroidX.Camera.Lifecycle;
using AndroidX.Core.Content;
using Java.Util;
using Java.Util.Concurrent;
using Microsoft.Maui;
using Microsoft.Maui.Essentials;
using Microsoft.Maui.Handlers;
using Microsoft.Extensions.DependencyInjection;
using static Android.Provider.Telephony;
using static Java.Util.Concurrent.Flow;
using Android.Hardware;
using static Android.Graphics.Paint;
using AndroidX.Camera.Camera2.InterOp;
using TestTcgScanner.Helpers;
using TestTcgScanner.Views.CameraView.Platforms.Android;

namespace TestTcgScanner.Views.CameraView
{
    public partial class CameraManager
    {
        private PreviewView previewView;
        private AndroidX.Camera.Core.Preview cameraPreview;
        private IExecutorService cameraExecutor;
        private CameraSelector cameraSelector = null;
        private ProcessCameraProvider cameraProvider;
        private ICamera camera;
        private ImageAnalysis imageAnalyzer;

        public NativePlatformCameraPreviewView CreateNativeView()
        {
            previewView = new PreviewView(Context.Context);
            cameraExecutor = Executors.NewSingleThreadExecutor();

            return previewView;
        }

        public void Connect()
        {
            var cameraProviderFuture = ProcessCameraProvider.GetInstance(Context.Context);

            cameraProviderFuture.AddListener(new Java.Lang.Runnable(() =>
            {
                // Used to bind the lifecycle of cameras to the lifecycle owner
                cameraProvider = (ProcessCameraProvider)cameraProviderFuture.Get();

                // Preview
                cameraPreview = new AndroidX.Camera.Core.Preview.Builder().Build();
                cameraPreview.SetSurfaceProvider(previewView.SurfaceProvider);

                // Frame by frame analyze
                imageAnalyzer = new ImageAnalysis.Builder()
                    .SetDefaultResolution(new Android.Util.Size(640, 480))
                    .SetBackpressureStrategy(ImageAnalysis.StrategyKeepOnlyLatest)
                    .Build();

                imageAnalyzer.SetAnalyzer(cameraExecutor, new FrameAnalyzer((buffer, size) =>
                    FrameReady?.Invoke(this, new CameraFrameBufferEventArgs(new PixelBufferHolder { Data = buffer, Size = size }))));

                UpdateCamera();

            }), ContextCompat.GetMainExecutor(Context.Context)); //GetMainExecutor: returns an Executor that runs on the main thread.
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Temporary")]
        public void Disconnect()
        { }

        public void UpdateCamera()
        {
            if (cameraProvider != null)
            {
                // Unbind use cases before rebinding
                cameraProvider.UnbindAll();

                var cameraLocation = CameraLocation;

                // Select back camera as a default, or front camera otherwise
                if (cameraLocation == CameraLocation.Rear && cameraProvider.HasCamera(CameraSelector.DefaultBackCamera))
                    cameraSelector = CameraSelector.DefaultBackCamera;
                else if (cameraLocation == CameraLocation.Front && cameraProvider.HasCamera(CameraSelector.DefaultFrontCamera))
                    cameraSelector = CameraSelector.DefaultFrontCamera;
                else
                    cameraSelector = CameraSelector.DefaultBackCamera;

                if (cameraSelector == null)
                    throw new System.Exception("Camera not found");

                // The Context here SHOULD be something that's a lifecycle owner
                if (Context.Context is AndroidX.Lifecycle.ILifecycleOwner lifecycleOwner)
                    camera = cameraProvider.BindToLifecycle(lifecycleOwner, cameraSelector, cameraPreview, imageAnalyzer);
            }
        }

        public void UpdateTorch(bool on)
        {
            camera?.CameraControl?.EnableTorch(on);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Temporary")]
        public void Focus(Point point)
        {
            if (point is null)
            {
                throw new ArgumentNullException(nameof(point));
            }

            //TODO: handle focus here
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Temporary")]
        public void AutoFocus()
        {

        }

        /// <inheritdoc />
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            cameraExecutor?.Shutdown();
            cameraExecutor?.Dispose();
        }
    }
}
