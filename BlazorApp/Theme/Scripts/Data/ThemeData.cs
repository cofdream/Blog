using BlazorApp.Theme.Post;
using BlazorApp.Theme.Service;

namespace BlazorApp.Theme.Data
{
    public class ThemeData
    {
        public readonly ThemeType ThemeType;
        public readonly string Name;
        public readonly Type Theme;

        public ThemeData(ThemeType themeType, Type type, string name = null)
        {
            ThemeType = themeType;
            Name = !string.IsNullOrEmpty(name) ? name : themeType.ToString();
            Theme = type;
        }
    }
}
