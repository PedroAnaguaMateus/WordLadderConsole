using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadderConsole
{
    public class ConsoleModel
    {
        public string FirstWord { get; set; }
        public string LastWord { get; set; }
        public List<string>? allWords { get; set; }

        public ConsoleModel()
        {

        }
    }
}
