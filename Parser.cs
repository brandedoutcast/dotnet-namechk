using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NameChk.CLI
{
    static class Parser
    {
        static IProvider Provider;
        internal static void Parse(string[] args)
        {
            if (args.Length == 0)
            {
                ShowHelp();
                return;
            }

            ShowVersion();
            RunProvider(args);
        }

        static void RunProvider(string[] names)
        {
            Provider = new NuGetProvider();
            Console.WriteLine();

            var Checks = Provider.CheckAvailability(names)
                                .Select(async c =>
                                {
                                    var (name, isAvailable) = await c;
                                    var color = isAvailable ? ConsoleColor.Green : ConsoleColor.Red;
                                    Console.ForegroundColor = color;
                                    Console.WriteLine($"   {name} {(isAvailable ? Constants.PACKAGE_AVAILABLE : Constants.PACKAGE_UNVAILABLE)}");
                                }).ToArray();

            Task.WaitAll(Checks);
            Console.ResetColor();
            Console.WriteLine();
        }

        static void ShowVersion()
        {
            var versionString = Assembly.GetEntryAssembly()
                                        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                        .InformationalVersion
                                        .ToString();

            Console.WriteLine($"{Constants.APP_NAME} v{versionString}");
            Console.WriteLine("----------------");
        }

        static void ShowHelp()
        {
            ShowVersion();

            Console.WriteLine($"\nUsage: {Constants.APP_NAME} [names...]");

            Console.WriteLine("\nnames:");
            Console.WriteLine("   list of names to check for the availability");

            Console.WriteLine("\nEx:");
            Console.WriteLine($"   {Constants.APP_NAME} miniature-fiesta reimagined-engine scaling-adventure");
            Console.WriteLine("\n   miniature-fiesta is available");
            Console.WriteLine("   reimagined-engine is unavailable");
            Console.WriteLine("   scaling-adventure is unavailable");
            Console.WriteLine();
        }
    }
}