using BlazorApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BlazorApp.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ZPostsModel : PageModel
    {

        public int Index => index;
        public static int index = 0;
        public string[] Layouts;
        public string Layout => Layouts[index];
        public string LayoutMode => Layouts[index];

        public int count =0;

        public ZPostsModel()
        {
            Layouts = new string[]
            {
                "ZGithub",
                "ZNews",
            };

            //index = 0;

        }

        public void OnGetOnClick()
        {
            index++;

            if (index >= Layouts.Length)
            {
                index = 0;
            }

            count++;
        }

    }
}