using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekvsStarWars;
public class ConsoleWrapper : IConsole
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }

    public void Write(string message)
    {
        Console.Write(message);
    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public void Clear()
    {
        //Added the if statment to be able to unit test. I am not 100% why this works
        //https://stackoverflow.com/questions/31692714/the-handle-is-invalid-exception-in-visual-studio-2015-test-runner
        if (!Console.IsOutputRedirected) Console.Clear();
    }
}
