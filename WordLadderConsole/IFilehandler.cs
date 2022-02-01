using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadderConsole
{
    public interface IFilehandler
    {
        public Task GetAllWordsFromFile(List<string> words, string filename);
        public Task WriteLadderToFile(string filename, List<string> words);
    }
}
