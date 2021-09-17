using System;
using Microsoft.Maui.Controls;

using TestTcgScanner.Models;
using TestTcgScanner.Services;

namespace TestTcgScanner.Pages
{
    public partial class MainPage : ContentPage
    {
        private IMtgApi MtgApi { get; }

        public MainPage()
        {
            InitializeComponent();

            MtgApi = ServiceProvider.GetService<IMtgApi>();
        }

        //private async void OnCounterClicked(object sender, EventArgs e)
        //{
        //    var searchParams = new MtgSearchParams
        //    {
        //        Name = "chosen"
        //    };

        //    var test = await MtgApi.GetCards(searchParams);

        //    Console.WriteLine(test.Content.Cards.Length);
        //}

        private async void OnDecksButtonClicked(object sender, EventArgs e) => await Application.Current.MainPage.Navigation.PushAsync(new DeckListPage());
    }
}
