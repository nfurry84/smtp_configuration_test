using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public static class HelloWorld
    {
        public static string GetHelloWorldMessage(string input)
        {
            return ("Hello World " + input).TrimEnd();
        }
    }
}
