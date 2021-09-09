using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;

namespace TestTcgScanner.Models
{
	public sealed class SectionModel
	{
		public SectionModel(Type type, string title, string description)
			: this(type, title, Colors.Blue, description)
		{
		}

		public SectionModel(Type type, string title, Color color, string description)
		{
			Type = type;
			Title = title;
			Description = description;
			Color = color;
		}

		public Type Type { get; }

		public string Title { get; }

		public string Description { get; }

		public Color Color { get; }
	}
}
