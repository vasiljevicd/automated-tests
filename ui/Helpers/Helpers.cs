using System;
using System.IO;
using ui.Config;

namespace ui.Helpers
{
	public class Helpers
	{


		public static string GetReportsFilePath()
		{
			string path;
            DateTime date = DateTime.Now;

            string osName = Environment.OSVersion.ToString();
			if (osName.Contains("Windows"))
			{
                string reportName ="\\"+ String.Format("{0:D}", date) + "\\" + String.Format("{0:t}", date) + "\\index.html";
                path = AppDomain.CurrentDomain.BaseDirectory.Replace("bin//Debug//netcoreapp7.0//", Configuration.folderForReports + reportName);
            } else
			{
                string reportName = "/" + String.Format("{0:D}", date) + "/" + String.Format("{0:t}", date)+ "/index.html";
                path = AppDomain.CurrentDomain.BaseDirectory.Replace("bin/Debug/netcoreapp7.0/", Configuration.folderForReports+reportName);
            }

			return path;
        }
	}
}

