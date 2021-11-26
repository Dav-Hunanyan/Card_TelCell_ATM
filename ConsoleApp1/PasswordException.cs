using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class PasswordException : Exception
    {
        public PasswordException(string massage) : base(massage)
        {

        }
    }
}
