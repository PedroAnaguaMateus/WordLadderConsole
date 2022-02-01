using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordLadderConsole
{
    public class ConsoleController 
    {
        private ConsoleModel model;

        public ConsoleController(string first, string last, List<string> allWords)
        {
            model = new ConsoleModel();
            model.FirstWord = first;
            model.LastWord = last;
            model.allWords = allWords;
        }

        public ConsoleController(ConsoleModel model)
        {
            this.model = model;
        }


        public IList<IList<string>> GetLadders()
        {
            IList<IList<string>> results = new List<IList<string>>();
            WordLadderLibrary.WordLadder library = new WordLadderLibrary.WordLadder();

            if (!string.IsNullOrEmpty(model.FirstWord) && !string.IsNullOrEmpty(model.LastWord) && model.allWords.Count > 0)
                results = library.FindLadders(model.FirstWord, model.LastWord, model.allWords);
           
            return results;
        }

    }
}
