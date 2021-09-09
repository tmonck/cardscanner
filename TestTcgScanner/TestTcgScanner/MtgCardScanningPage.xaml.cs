using Microsoft.Maui.Controls;
using TestTcgScanner.Pages;
using Xamarin.CommunityToolkit.UI.Views;

namespace TestTcgScanner
{
    public partial class MtgCardScanningPage : BasePage
    {
        public MtgCardScanningPage()
        {
            InitializeComponent();
			zoomLabel.Text = string.Format("Zoom: {0}", zoomSlider.Value);
		}

		private	void ZoomSlider_ValueChanged(object? sender, ValueChangedEventArgs e)
		{
			cameraView.Zoom = (float)zoomSlider.Value;
			zoomLabel.Text = string.Format("Zoom: {0}", Math.Round(zoomSlider.Value));
		}

		private	void VideoSwitch_Toggled(object? sender, ToggledEventArgs e)
		{
			var captureVideo = e.Value;

			if (captureVideo)
				cameraView.CaptureMode = CameraCaptureMode.Video;
			else
				cameraView.CaptureMode = CameraCaptureMode.Photo;

			//previewPicture.IsVisible = !captureVideo;
			//previewVideo.IsVisible = captureVideo;

			doCameraThings.Text = e.Value ? "Start Recording"
				: "Snap Picture";
		}

		// You can also set it to Default and External
		private	void FrontCameraSwitch_Toggled(object? sender, ToggledEventArgs e)
			=> cameraView.CameraOptions = e.Value ? CameraOptions.Front : CameraOptions.Back;

		// You can also set it to Torch (always on) and Auto
		private	void FlashSwitch_Toggled(object? sender, ToggledEventArgs e)
			=> cameraView.FlashMode = e.Value ? CameraFlashMode.On : CameraFlashMode.Off;

		private void DoCameraThings_Clicked(object? sender, EventArgs e)
		{
			cameraView.Shutter();
			doCameraThings.Text = cameraView.CaptureMode == CameraCaptureMode.Video
				? "Stop Recording"
				: "Snap Picture";
		}

		private	void CameraView_OnAvailable(object? sender, bool e)
		{
			if (e)
			{
				zoomSlider.Value = cameraView.Zoom;
				var max = cameraView.MaxZoom;
				if (max > zoomSlider.Minimum && max > zoomSlider.Value)
					zoomSlider.Maximum = max;
				else
					zoomSlider.Maximum = zoomSlider.Minimum + 1; // if max == min throws exception
			}

			doCameraThings.IsEnabled = e;
			zoomSlider.IsEnabled = e;
		}

		private	void CameraView_MediaCaptured(object? sender, MediaCapturedEventArgs e)
		{
			switch (cameraView.CaptureMode)
			{
				default:
				case CameraCaptureMode.Default:
				case CameraCaptureMode.Photo:
					//previewVideo.IsVisible = false;
					//previewPicture.IsVisible = true;
					//previewPicture.Rotation = e.Rotation;
					//previewPicture.Source = e.Image;
					doCameraThings.Text = "Snap Picture";
					break;
				case CameraCaptureMode.Video:
					//previewPicture.IsVisible = false;
					//previewVideo.IsVisible = true;
					//previewVideo.Source = e.Video;
					doCameraThings.Text = "Start Recording";
					break;
			}
		}
	}
}
