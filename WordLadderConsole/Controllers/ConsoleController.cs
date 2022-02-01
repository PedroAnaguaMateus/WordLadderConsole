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
        private readonly ConsoleModel model;

        public ConsoleController(string first, string last, List<string> allWords)
        {
            model = new ConsoleModel
            {
                FirstWord = first,
                LastWord = last,
                allWords = allWords
            };
        }


        public IList<IList<string>> GetLadders()
        {
            List<IList<string>> results = new();
            WordLadderLibrary.WordLadder library = new();
            
            if (!string.IsNullOrEmpty(model.FirstWord) && !string.IsNullOrEmpty(model.LastWord) && model.allWords.Count > 0)
                results = library.FindLadders(model.FirstWord, model.LastWord,
                    model.allWords.Where(x => x.Length == model.FirstWord.Length 
                    && (x.StartsWith(model.FirstWord.FirstOrDefault()) || x.StartsWith(model.LastWord.FirstOrDefault()))
                    && (x.EndsWith(model.FirstWord.LastOrDefault()) || x.EndsWith(model.LastWord.LastOrDefault()))).ToList()).Reverse().ToList();
           
            return results;
        }

    }
}
