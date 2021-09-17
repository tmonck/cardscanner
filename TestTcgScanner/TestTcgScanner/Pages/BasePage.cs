using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using TestTcgScanner.Models;
using System.Windows.Input;

namespace TestTcgScanner.Pages
{
    public class BasePage : ContentPage
    {
        public BasePage()
        {
            //NavigateCommand = CommandFactory.Create<SectionModel>(sectionModel =>
            //{
            //    if (sectionModel != null)
            //        return Navigation.PushAsync(PreparePage(sectionModel));

            //    return Task.CompletedTask;
            //});

            NavigateCommand = new Command(Navigate);
        }

        private async void Navigate(object sectionModel)
        {
            await Navigation.PushAsync(PreparePage((SectionModel)sectionModel));
        }

        public Color? DetailColor { get; set; }

        public ICommand NavigateCommand { get; }

        private ContentPage PreparePage(SectionModel model)
        {
            var page = Activator.CreateInstance(model.Type) as BasePage;
            page.Title = model.Title;
            page.DetailColor = model.Color;
            page.SetAppThemeColor(BackgroundColorProperty, Colors.White, Colors.Black);
            return page;
        }
    }
}
