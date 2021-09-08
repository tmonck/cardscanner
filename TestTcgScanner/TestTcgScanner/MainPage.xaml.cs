using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Microsoft.Maui.Essentials;
using TestTcgScanner.Models;
using TestTcgScanner.Services;

namespace TestTcgScanner
{
    public partial class MainPage : ContentPage
    {
        private IMtgApi _mtgApi { get; }

        public MainPage()
        {
            InitializeComponent();

            _mtgApi = ServiceProvider.GetService<IMtgApi>();
        }

        int count = 0;
        private async void OnCounterClicked(object sender, EventArgs e)
        {
            //count++;
            //CounterLabel.Text = $"Current count: {count}";

            var searchParams = new MtgSearchParams
            {
                Name = "chosen"
            };

            //working on this here
            var test = await _mtgApi.GetCards(searchParams);

            //CounterLabel.Text = $"#Cards: {test.Count}";
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
