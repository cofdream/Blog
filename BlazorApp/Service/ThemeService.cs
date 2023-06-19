using BlazorApp.Data;
using BlazorApp.Shared;

namespace BlazorApp.Service
{
	public class ThemeService
	{
		private Theme[] Themes;

		public ThemeService()
		{
			Themes = new Theme[]
			{
				new Theme(){ ThemeType = typeof(MainLayout)},
				new Theme(){ ThemeType = typeof(BlogLayout)},
			};
		}

		public Theme GetTheme()
		{
			return Themes[0];
		}
    }
}
