/// <summary>
/// Copyright (c) 2021 Ahmad N. Chatila.
/// 
/// Author:
///     Ahmad N. Chatila
///     
/// Date Created:
///     05 May 2021
///     
/// </summary>
using System;
using System.Text;

namespace EasyMap.Console
{
    class Program
    {
        static void Main(string[] a)
        {
            ConsoleHelpers.PrintTitle();

            var args = new Args(a);
            if (!args.IsValid)
            {
                foreach (var i in args.ErrorDetails)
                {
                    System.Console.WriteLine($"{i.Key}   = ${i.Value}");
                }

                goto Exit;
            }

            var config = new ConfigModel(args.ConfigFile);
            if (!config.IsValid)
            {
                foreach (var i in config.ErrorDetails)
                {
                    System.Console.WriteLine($"{i.Key}   = ${i.Value}");
                }

                goto Exit;
            }

            var dsInfo = new DataSourceInfo(args.SourceFile, config);

            var translator = new Translator(dsInfo, config);
            translator.SaveToFile("file.csv");

        Exit:
            System.Console.WriteLine("\nPress ENTER to exit.");
            System.Console.ReadLine();
        }
    }
}
