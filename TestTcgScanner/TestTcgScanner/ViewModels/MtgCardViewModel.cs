using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AsyncAwaitBestPractices;
using AsyncAwaitBestPractices.MVVM;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using TestTcgScanner.Models;
using TestTcgScanner.Services;
using TestTcgScanner.ViewModels.Base;

namespace TestTcgScanner.ViewModels
{
    internal class MtgCardViewModel : BaseViewModel
    {
        private WeakEventManager<string> _pullToRefreshEventManager = new();
        private readonly MtgApiService _mtgCardApiService;
        private bool _isListRefreshing;

        public ICommand RefreshCommand { get; }

        public MtgCardViewModel(MtgApiService mtgCardApiService)
        {
            _mtgCardApiService = mtgCardApiService;

            RefreshCommand = new AsyncCommand(ExecuteRefreshCommand);

            BindingBase.EnableCollectionSynchronization(Cards, null, ObservableCollectionCallback);
        }

        public ObservableCollection<MtgCard> Cards { get; } = new();

        public bool IsListRefreshing
        {
            get => _isListRefreshing;
            set => SetProperty(ref _isListRefreshing, value);
        }

        public event EventHandler<string> PullToRefreshFailed
        {
            add => _pullToRefreshEventManager.AddEventHandler(value);
            remove => _pullToRefreshEventManager.RemoveEventHandler(value);
        }

        private async Task ExecuteRefreshCommand()
        {
            Cards.Clear();

            try
            {
                //var cardResults = GetCards(new MtgCard()
                //{
                //    Name = "chosen"
                //}).ConfigureAwait(false);

                //await foreach (var cardResult in cardResults)
                //{
                //    var test = cardResult;

                //}
            }
            catch (Exception e)
            {
                OnPullToRefreshFailed(e.ToString());
            }
            finally
            {
                IsListRefreshing = false;
            }
        }

        private async IAsyncEnumerable<MtgCard> GetCards(MtgSearchParams filterParams)
        {
            //not working yet here
            var cardResults = await _mtgCardApiService.GetCards(filterParams).ConfigureAwait(false);

            foreach (var result in cardResults.Content)
            {
                yield return result;
            }
        }

        private void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
        {
            MainThread.BeginInvokeOnMainThread(accessMethod);
        }

        private void OnPullToRefreshFailed(string message) => _pullToRefreshEventManager.RaiseEvent(this, message, nameof(PullToRefreshFailed));
    }
}
