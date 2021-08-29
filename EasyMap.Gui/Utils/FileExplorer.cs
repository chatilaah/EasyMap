using System;
using System.IO;

namespace EasyMap.Gui.Utils
{
    internal class FileExplorer
    {
        /// <summary>
        /// Retrieves the actual Windows Explorer executable file located in the %WINDIR% directory.
        /// </summary>
        private static string ExplorerExe => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "explorer.exe");

        /// <summary>
        /// Opens Windows Explorer to the specified file/folder and highlights it.
        /// </summary>
        /// <param name="filename"></param>
        public static void OpenWithHighlight(string filename)
        {
            if (!File.Exists(ExplorerExe))
            {
                throw new FileNotFoundException("Windows Explorer cannot be found. This calls for an OS repair!");
            }

            System.Diagnostics.Process.Start(ExplorerExe, $"/select,\"{filename}\"");
        }

        /// <summary>
        /// Opens the file or folder.
        /// </summary>
        /// <param name="filename"></param>
        public static void Open(string filename)
        {
            if (!File.Exists(ExplorerExe))
            {
                throw new FileNotFoundException("Windows Explorer cannot be found. This calls for an OS repair!");
            }

            System.Diagnostics.Process.Start(ExplorerExe, filename);
        }
    }
}
