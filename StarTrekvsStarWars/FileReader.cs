using System;

namespace StarTrekvsStarWars;
public class FileReader
{
    public List<string[]> createListFromFile(StreamReader reader)
    {
        List<string[]> totalFileValues = new List<string[]>();
        var headerLine = reader.ReadLine();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line != null)
            {
                var singleRowValues = line.Split(',');
                totalFileValues.Add(singleRowValues);
            }
        }
        return totalFileValues;
    }
}
