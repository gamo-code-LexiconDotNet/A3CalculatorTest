using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Calculator
    {
        private readonly Menu menu;
        private readonly HandleOperations handleOperations;
        public Calculator()
        {
            menu = new Menu(new ConsoleWrapper());
            handleOperations = new HandleOperations(
                new HandleInput(
                    new ConsoleWrapper()),
                new Operations(),
                new ConsoleWrapper());

            SetupMenu();
        }

        private void SetupMenu()
        {
            menu.Heading = "[Lexicon C#/.Net Programming] Assignment 3 - Calculator Test]";
            menu.Title = "Choose what to do:";
            menu.AddItem("1", "Add (a + b + c + ...)", handleOperations.Add);
            menu.AddItem("2", "Subtract (a - b - c - ...)", handleOperations.Subtract);
            menu.AddItem("3", "Multiply (a * b)", handleOperations.Multiply);
            menu.AddItem("4", "Divide (a / b)", handleOperations.Divide);
            menu.AddItem("5", "Modulo (a mod b)", handleOperations.Modulo);
            menu.AddItem("6", "Power (a ^ b)", handleOperations.Power);
            menu.AddItem("7", "Root (a ^ 1/b)", handleOperations.Root);
            menu.AddItem("8", "Log (Log a / Log b)", handleOperations.Log);
        }

        public void Run()
        {
            menu.Run();
        }
    }
}
