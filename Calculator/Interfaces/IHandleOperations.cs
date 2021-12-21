using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public interface IHandleOperations
    {
        public void Add();
        public void Subtract();
        public void Divide();
        public void Multiply();
        public void Modulo();
        public void Root();
        public void Log();
    }
}
