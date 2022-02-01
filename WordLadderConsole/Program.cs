using WordLadderConsole;

ConsoleController consoleControler; 
Filehandler filehandler = new Filehandler();
List<string> allwords = new List<string>();
string firstWord, lastWord = string.Empty;
//bool fileExists = false;

//do (!fileExists)
//{
//    string filename = Console.ReadLine() ?? String.Empty;
//    if (File.Exists(Environment.CurrentDirectory + "\\" + filename))
//    {
//        filehandler.GetAllWordsFromFile(allwords, filename).Start();
//        fileExists = true;
//    }
//}while()

Console.WriteLine(Constants.DictonaryFileRequest);
await filehandler.GetAllWordsFromFile(allwords, Environment.CurrentDirectory + "\\" + (Console.ReadLine() ?? String.Empty));

Console.WriteLine(Constants.StartWordRequest);
firstWord = Console.ReadLine() ?? string.Empty;

Console.WriteLine(Constants.LastWordRequest);
lastWord = Console.ReadLine() ?? string.Empty;

Console.WriteLine(Constants.AnswerFileRequest);
var resultsfile = Console.ReadLine();


consoleControler = new ConsoleController(firstWord, lastWord, allwords);
var results = consoleControler.GetLadders().Reverse().ToList();
if (results.Count > 0)
    await filehandler.WriteLadderToFile(Environment.CurrentDirectory + "\\" + resultsfile, results[0].ToList<string>());
