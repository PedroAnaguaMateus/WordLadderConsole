using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadderLibrary
{
    public interface IWordLadder
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList);
    }
}
