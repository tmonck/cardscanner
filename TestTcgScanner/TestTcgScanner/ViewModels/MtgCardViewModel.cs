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
        private readonly MtgApiService _mtgCardApiService;

        public MtgCardViewModel(MtgApiService mtgCardApiService)
        {
            _mtgCardApiService = mtgCardApiService;

            BindingBase.EnableCollectionSynchronization(Cards, null, ObservableCollectionCallback);
        }

        public ObservableCollection<MtgCard> Cards { get; } = new();

#pragma warning disable IDE0051 // Remove unused private members
        private async Task<MtgSearchResult> GetCards(MtgSearchParams filterParams)
#pragma warning restore IDE0051 // Remove unused private members
        {
            return (await _mtgCardApiService.GetCards(filterParams)).Content!;
        }

        private void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
        {
            MainThread.BeginInvokeOnMainThread(accessMethod);
        }
    }
}
