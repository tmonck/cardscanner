using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;

namespace TestTcgScanner.Views.CameraView
{
    public partial class CameraCardReaderViewHandler : ViewHandler<ICameraCardReaderView, NativePlatformCameraPreviewView>
    {
        public static readonly PropertyMapper<ICameraCardReaderView, CameraCardReaderViewHandler> CameraCardReaderViewMapper = new()
        {
            [nameof(ICameraCardReaderView.Options)] = MapOptions,
            [nameof(ICameraCardReaderView.IsDetecting)] = MapIsDetecting,
            [nameof(ICameraCardReaderView.IsTorchOn)] = (handler, virtualView) => handler._cameraManager.UpdateTorch(virtualView.IsTorchOn),
            [nameof(ICameraCardReaderView.CameraLocation)] = (handler, virtualView) => handler._cameraManager.UpdateCameraLocation(virtualView.CameraLocation)
        };

        public static CommandMapper<ICameraCardReaderView, CameraCardReaderViewHandler> CameraCardReaderCommandMapper = new()
        {
            [nameof(ICameraCardReaderView.Focus)] = MapFocus,
            [nameof(ICameraCardReaderView.AutoFocus)] = MapAutoFocus,
        };

        public CameraCardReaderViewHandler() : base(CameraCardReaderViewMapper)
        {
        }

        public CameraCardReaderViewHandler(PropertyMapper mapper = null) : base(mapper ?? CameraCardReaderViewMapper)
        {
        }

        public event EventHandler<CardDetectionEventArgs> CardDetected;
        public event EventHandler<CameraFrameBufferEventArgs> FrameReady;

        private CameraManager _cameraManager;

        protected ICardReader CardReader
            => Services.GetService(typeof(ICardReader)) as ICardReader;

        protected override NativePlatformCameraPreviewView CreateNativeView()
        {
            if (_cameraManager == null)
                _cameraManager = new(MauiContext, VirtualView?.CameraLocation ?? CameraLocation.Rear);
            var v = _cameraManager.CreateNativeView();
            return v;
        }

        protected override async void ConnectHandler(NativePlatformCameraPreviewView nativeView)
        {
            base.ConnectHandler(nativeView);

            if (await CameraManager.CheckPermissions())
                _cameraManager.Connect();

            _cameraManager.FrameReady += CameraManager_FrameReady;
        }

        protected override void DisconnectHandler(NativePlatformCameraPreviewView nativeView)
        {
            _cameraManager.FrameReady -= CameraManager_FrameReady;

            _cameraManager.Disconnect();

            base.DisconnectHandler(nativeView);
        }

        private void CameraManager_FrameReady(object sender, CameraFrameBufferEventArgs e)
        {
            FrameReady?.Invoke(this, e);

            if (VirtualView.IsDetecting)
            {
                var card = CardReader.Detect(e.Data);

                CardDetected?.Invoke(this, new CardDetectionEventArgs(card));
            }
        }

        public static void MapOptions(CameraCardReaderViewHandler handler, ICameraCardReaderView cameraBarcodeReaderView)
            => handler.CardReader.Options = cameraBarcodeReaderView.Options;

        public static void MapIsDetecting(CameraCardReaderViewHandler handler, ICameraCardReaderView cameraBarcodeReaderView)
        { }

        public void Focus(Point point)
            => _cameraManager?.Focus(point);

        public void AutoFocus()
            => _cameraManager?.AutoFocus();

        public static void MapFocus(CameraCardReaderViewHandler handler, ICameraCardReaderView cameraBarcodeReaderView, object? parameter)
        {
            if (parameter is not Point point)
                throw new ArgumentOutOfRangeException(nameof(point), "Focus value is out of range");

            handler.Focus(point);
        }

        public static void MapAutoFocus(CameraCardReaderViewHandler handler, ICameraCardReaderView cameraBarcodeReaderView, object? parameters)
            => handler.AutoFocus();
    }
}
