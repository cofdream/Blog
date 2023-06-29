using System;
using System.IO;

namespace BlogTool
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				if (args != null && args.Length > 0)
				{
					ExportHtml(args[0]);
				}
			}
			catch (Exception)
			{
				Console.WriteLine();
			}
		}


		private static void ExportHtml(string filePath)
		{
			if (File.Exists(filePath) == false) return;

			var html = string.Empty;
			var lines = File.ReadAllLines(filePath);
			foreach (var line in lines)
			{
				if (line.StartsWith("<div "))
				{
					html = line;
					break;
				}
			}

			if (string.IsNullOrEmpty(html) == false)
			{
				File.WriteAllText(filePath, html);
				Console.WriteLine($"{nameof(ExportHtml)} success done.");
			}
			else
			{
				Console.WriteLine($"{nameof(ExportHtml)} success done.");
			}
		}
	}
}
