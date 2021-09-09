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

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var searchParams = new MtgSearchParams
            {
                Name = "chosen"
            };

            var test = await _mtgApi.GetCards(searchParams);
        }

		    private void CameraView_OnAvailable(object? sender, bool e)
        {
			    Console.WriteLine("OnAvailable");
        }

    private async void OnDecksButtonClicked(object sender, EventArgs e) => await App.Current.MainPage.Navigation.PushAsync(new DeckListPage());
    private async void OnTakePicture(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new MtgCardScanningPage());
        }
    }
}
