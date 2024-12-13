using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("__  __  __");
            ConsoleManager consoleManager = new ConsoleManager();
            consoleManager.run();
            Console.ReadKey();
        }
    }
}
