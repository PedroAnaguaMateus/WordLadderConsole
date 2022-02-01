using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadderConsole
{
    public class Filehandler : IFilehandler
    {
        public Task GetAllWordsFromFile(List<string> words, string filename)
        {
            return Task.Run(() => words.AddRange( File.ReadAllLines(filename)));
        }

        public Task WriteLadderToFile(string filename, List<string> words)
        {
            return Task.Run(() => File.WriteAllLines(filename, words));
        }
    }
}

