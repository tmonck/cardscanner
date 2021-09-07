using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace TestTcgScanner
{
    public partial class MtgCardScanningPage : ContentPage
    {
        public MtgCardScanningPage()
        {
            InitializeComponent();
            MediaPicker.CapturePhotoAsync();
        }

        private string CardName;
        private string CardNumber;
        private string CardSet;
        private void OnCounterClicked(object sender, EventArgs e)
        {
            CounterLabel.Text = $"Current count: 0";
        }
    }
}
