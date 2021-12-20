using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public interface IConsoleWrapper
    {
        string ReadLine();
        char ReadKey();
        void WriteLine(string value);
        void Write(string value);
        void Clear();
    }
}
