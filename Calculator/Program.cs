using System;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleWrapper consoleWrapper = new ConsoleWrapper();
            Menu menu = new Menu(consoleWrapper);
            menu.Run();
        }
    }
}
