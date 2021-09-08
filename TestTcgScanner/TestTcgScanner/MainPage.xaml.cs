using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Microsoft.Maui.Essentials;

namespace TestTcgScanner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        int count = 0;
        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
            CounterLabel.Text = $"Current count: {count}";
        }

        private async void OnTakePicture(object sender, EventArgs e)
        {
            if (MediaPicker.IsCaptureSupported)
            {
                await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = "TempPic"
                });
            }
        }
    }
}
