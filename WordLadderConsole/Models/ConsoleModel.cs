using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadderConsole
{
    public class ConsoleModel
    {
        public string FirstWord { get; set; } = String.Empty;
        public string LastWord { get; set; } = String.Empty;
        public List<string> allWords { get; set; } = new List<string>();

        public ConsoleModel()
        {

        }
    }
}
