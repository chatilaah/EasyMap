using System;
using System.Diagnostics;
using System.Reflection;

namespace EasyMap.Console
{
    internal class ConsoleHelpers
    {
        public static void PrintTitle()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            var companyName = $"Developed by {fvi.CompanyName}";
            var productName = fvi.ProductName;
            var productVersion = fvi.ProductVersion;

            System.Console.WriteLine($"{productName} [Version {productVersion}]\n{companyName}");

            for (int i = 0; i < companyName.Length; i++)
            {
                System.Console.Write("=");
            }

            System.Console.WriteLine("\n");
        }
    }
}
