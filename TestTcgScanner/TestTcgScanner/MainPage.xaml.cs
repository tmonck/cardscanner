using Microsoft.Maui.Controls;
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

		private void CameraView_OnAvailable(object? sender, bool e)
        {
			Console.WriteLine("OnAvailable");
        }

        private async void OnTakePicture(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MtgCardScanningPage());
        }
    }
}
