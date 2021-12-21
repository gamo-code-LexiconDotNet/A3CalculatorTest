using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public interface IHandleInput
    {
        public T[] ReadNumbers<T>(int numbersToRead);
    }
}
