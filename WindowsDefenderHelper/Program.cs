using System;
using static WindowsDefenderHelper;

internal class Program
{
    static void Main(string[] args)
    {
        if (!IsUserAdministrator())
        {
            Console.Write("This program requires administrator privilege. Press any key to exit...");
            Console.ReadKey();
            return;
        }

        var path = @"C:\Temp";

        Console.WriteLine("Current ExclusionPath:");
        Console.WriteLine(GetExclusionPath());

        Console.WriteLine();
        Console.Write($"Adding \"{path}\" to ExclusionPath... ");
        AddExclusionPath(path);
        Console.WriteLine($"Added.");
        Console.WriteLine(GetExclusionPath());

        Console.WriteLine();
        Console.Write($"Removing \"{path}\" from ExclusionPath... ");
        RemoveExclusionPath(path);
        Console.WriteLine($"Removed.");
        Console.WriteLine(GetExclusionPath());

        Console.WriteLine();
        Console.Write("All done. Press any key to exit...");
        Console.ReadKey();
    }
}
