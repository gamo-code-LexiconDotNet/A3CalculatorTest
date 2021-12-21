using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Interfaces
{
    public interface IMenu
    {
        public void Run();
        public void AddItem(string option, string text, Action action);
    }
}
