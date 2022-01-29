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
        public string lastWord;

        public ConsoleController()
        {
            model = new ConsoleModel();
        }

        public ConsoleController(ConsoleModel model)
        {
            this.model = model;
        }

        public void SetFirstWord(string firstWord)
        {
            model.FirstWord = firstWord;
        }

        public void SetLastWord(string lastWord)
        {
            model.LastWord = lastWord;
        }

        public bool GetDictonaryFile(string filename)
        {
            if(File.Exists(Environment.CurrentDirectory + "\\" + filename))
            {
                model.allWords = new List<string>(File.ReadAllLines(filename));
                
                return true;
            }

            return false;
        }

        public IList<IList<string>> GetLadders()
        {
            IList<IList<string>> results = new List<IList<string>>();
            WordLadderLibrary.WordLadder library = new WordLadderLibrary.WordLadder();

            if (string.IsNullOrEmpty(model.FirstWord) && string.IsNullOrEmpty(model.LastWord))
                results = library.FindLadders(model.FirstWord, model.LastWord, model.allWords);
           
            return results;
        }

    }
}
