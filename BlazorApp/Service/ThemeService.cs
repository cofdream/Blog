using BlazorApp.Data;
using BlazorApp.Shared;

namespace BlazorApp.Service
{
	public class ThemeService
	{
		private Data.Theme[] Themes;

		public ThemeService()
		{
			Themes = new Data.Theme[]
			{
				new Data.Theme(){ ThemeType = typeof(MainLayout)},
				new Data.Theme(){ ThemeType = typeof(BlogLayout)},
			};
		}

		public Data.Theme GetTheme()
		{
			return Themes[0];
		}
    }
}
