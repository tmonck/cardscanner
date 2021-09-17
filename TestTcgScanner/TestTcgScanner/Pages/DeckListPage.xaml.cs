using System;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace TestTcgScanner.Pages
{
    public partial class DeckListPage : ContentPage
    {
        public DeckListPage()
        {
            InitializeComponent();
        }

        private async void OnAddCardButtonClicked(object sender, EventArgs e) => await Application.Current.MainPage.Navigation.PushAsync(new MtgCardScanningPage());
    }
}
