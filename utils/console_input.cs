using System;

namespace LibraryApp.Utilities
{
    public static class ConsoleInput
    {
        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}