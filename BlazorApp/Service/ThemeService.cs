using BlazorApp.Data;
using BlazorApp.Shared;
using BlazorApp.Theme.Blog;
using BlazorApp.Theme.Post;

namespace BlazorApp.Service
{
    public class ThemeService
    {
        private ThemeData[] Themes;
        private List<ThemeData> blogPostsThems;

        public ThemeService()
        {
            Themes = new Data.ThemeData[]
            {
                new Data.ThemeData(){ ThemeType = typeof(MainLayout)},
                new Data.ThemeData(){ ThemeType = typeof(BlogLayout)},
            };

            blogPostsThems = new List<ThemeData>();
            blogPostsThems.Add(new ThemeData() { Name = "Github", ThemeType = typeof(ThemePostGithub) });
            blogPostsThems.Add(new ThemeData() { Name = "Newsprint", ThemeType = typeof(ThemePostNewsprint) });
            blogPostsThems.Add(new ThemeData() { Name = "Night", ThemeType = typeof(ThemePostNight) });
            blogPostsThems.Add(new ThemeData() { Name = "Pixyll", ThemeType = typeof(ThemePostPixyll) });
            blogPostsThems.Add(new ThemeData() { Name = "Whitey", ThemeType = typeof(ThemePostWhitey) });

        }

        public ThemeData GetTheme()
        {
            return Themes[0];
        }

        public List<ThemeData> GetPostThemes()
        {
            return blogPostsThems;
        }
    }
}
