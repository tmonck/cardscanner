using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using TestTcgScanner.Models;
using Xamarin.CommunityToolkit.ObjectModel;
using System.Windows.Input;

namespace TestTcgScanner.Pages
{
	public class BasePage : ContentPage
	{
		public BasePage()
		{
			NavigateCommand = CommandFactory.Create<SectionModel>(sectionModel =>
			{
				if (sectionModel != null)
					return Navigation.PushAsync(PreparePage(sectionModel));

				return Task.CompletedTask;
			});
		}

		public Color? DetailColor { get; set; }

		public ICommand NavigateCommand { get; }

		ContentPage PreparePage(SectionModel model)
		{
            var page = Activator.CreateInstance(model.Type) as BasePage;
			page.Title = model.Title;
			page.DetailColor = model.Color;
			page.SetAppThemeColor(BackgroundColorProperty, Colors.White, Colors.Black);
			return page;
		}
	}
}
