using BlazorApp.Theme.Data;
using BlazorApp.Theme.Post;
using System.Reflection;

namespace BlazorApp.Theme.Service
{
    public enum ThemeType : byte
    {
        None = 0,
        Github,
        Newsprint,
        Night,
        Pixyll,
        Whitey,
    }

    public class ThemeService
    {
        private readonly ThemeData[] eblogPostsThems;
        public IEnumerable<ThemeData> BlogPostsThemes => eblogPostsThems;

        public ThemeType CurrentTheme { get; set; } = ThemeType.None;

        public ThemeService()
        {
            eblogPostsThems = new ThemeData[]
            {
                new(ThemeType.None,       typeof(ThemePostNone)),
                new(ThemeType.Github,     typeof(ThemePostGithub)),
                new(ThemeType.Newsprint,  typeof(ThemePostNewsprint)),
                new(ThemeType.Night,      typeof(ThemePostNight)),
                new(ThemeType.Pixyll,     typeof(ThemePostPixyll)),
                new(ThemeType.Whitey,     typeof(ThemePostWhitey)),
            };
        }

        public ThemeData GetPostTheme(ThemeType themeType)
        {
            return eblogPostsThems[(int)themeType];
        }

        public void ReadTheme()
        {

        }

        public void SaveTheme()
        {

        }

    }
}
