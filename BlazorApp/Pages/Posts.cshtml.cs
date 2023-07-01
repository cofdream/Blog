using BlazorApp.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Reflection;


namespace BlazorApp.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class PostsModel : PageModel
    {
        public int Index => index;
        public static int index = 0;
        public string[] Layouts;
        public string Layout => Layouts[index];
        public string LayoutMode => Layouts[index];

        public string? message;

        public string? PostHtml;
        private string? url;
        public PostsModel()
        {
            Layouts = new string[]
            {
                "~/Theme/ThemePostGithub.cshtml",
                "~/Theme/ThemePostNews.cshtml",
                "~/Theme/ThemePostNight.cshtml",
                "~/Theme/ThemePostPixyll.cshtml",
                "~/Theme/ThemePostWhitey.cshtml",
            };

            //index = 0;
            message = $"{LayoutMode} {Index}  {url}";
        }

        public async Task<IActionResult> OnGetAsync(string url)
        {
            if (url == null)
            {
                return NotFound();
            }
            this.url = url;
            message = $"{LayoutMode} {Index}  {url}";
            // todo 异步加载 post
            //Customer = await _context.Customer.FirstOrDefaultAsync(m => m.Id == id);

            PostHtml = "<h1 id='unity编辑器自定义资源导入'>Unity编辑器自定义资源导入</h1>\n<h3 id='涉及类属性'>涉及类/属性</h3>\n<p><a href='https://docs.unity3d.com/cn/current/ScriptReference/AssetPostprocessor.html'>ScriptedImporter</a></p>\n<blockquote>\n    <p>自定义资源导入器的抽象基类。脚本化导入器是与特定文件扩展名关联的脚本。Unity 的资源管线调用它们来将关联文件的内容转换为资源。</p>\n</blockquote>\n<p><a href='https://docs.unity3d.com/cn/current/ScriptReference/AssetImporters.ScriptedImporterAttribute.html'>ScriptedImporterAttribute</a></p>\n<blockquote>\n    <p>用于向 Unity 的资源导入管线注册派生自 ScriptedImporter 的自定义资源导入器的类属性。使用 ScriptedImporterAttribute 类可向资源管线注册自定义导入器。</p>\n</blockquote>\n<p><a href='https://docs.unity3d.com/cn/current/ScriptReference/AssetDatabase.SetImporterOverride.html'>AssetDatabase.SetImporterOverride<T>(string path) where T : ScriptedImporter</a></p>\n<blockquote>\n    <p>将特定导入器设置为用于资源。</p>\n</blockquote>\n<p><a href='https://docs.unity3d.com/cn/current/ScriptReference/AssetPostprocessor.html'>AssetPostprocessor</a></p>\n<blockquote>\n    <p>在资源导入或重新导入以后由unity调用。主要使用 OnPreprocessAsset() 或者OnPostprocessAllAssets</p>\n</blockquote>\n<p>&nbsp;</p>";



            if (PostHtml == null)
            {
                return NotFound();
            }
            return Page();
        }

        public void OnGetOnClick()
        {
            index++;

            if (index >= Layouts.Length)
            {
                index = 0;
            }

            message = $"{LayoutMode} {Index}  {url}";
        }

        public void OnClick()
        {
            OnGetOnClick();
        }

    }
}