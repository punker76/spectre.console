using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Spectre.Console;

namespace Sample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Use the static API to write some things to the console.
            AnsiConsole.Foreground = Color.Chartreuse2;
            AnsiConsole.Style = Styles.Underline | Styles.Bold;
            AnsiConsole.WriteLine("Hello World!");
            AnsiConsole.Reset();
            AnsiConsole.WriteLine($"Capabilities: {AnsiConsole.Capabilities}");
            AnsiConsole.WriteLine($"Width={AnsiConsole.Width}, Height={AnsiConsole.Height}");
            AnsiConsole.WriteLine("Good bye!");
            AnsiConsole.WriteLine();

            // We can get the default console via the static API.
            var console = AnsiConsole.Console;

            // Or you can build it yourself the old fashion way.
            console = AnsiConsole.Create(
                new AnsiConsoleSettings()
                {
                    Ansi = AnsiSupport.Yes,
                    ColorSystem = ColorSystemSupport.Standard,
                    Out = Console.Out,
                });

            // In this case, we will find the closest colors
            // and downgrade them to the specified color system.
            console.Foreground = Color.Chartreuse2;
            console.Style = Styles.Underline | Styles.Bold;
            console.WriteLine("Hello World!");
            console.ResetColors();
            console.ResetStyle();
            console.WriteLine($"Capabilities: {console.Capabilities}");
            console.WriteLine($"Width={AnsiConsole.Width}, Height={AnsiConsole.Height}");
            console.WriteLine("Good bye!");
            console.WriteLine();
        }
    }
}



