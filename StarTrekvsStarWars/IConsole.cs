using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekvsStarWars;
public interface IConsole
{
    void Write(string message);
    void WriteLine(string message);
    string ReadLine();
}
