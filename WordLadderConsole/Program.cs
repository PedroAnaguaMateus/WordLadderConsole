using WordLadderConsole;

ConsoleController consoleControler = new ConsoleController();

do
{
    Console.WriteLine(Constants.DictonaryFileRequest); 
} while (!consoleControler.GetDictonaryFile(Console.ReadLine() ?? string.Empty));

 Console.WriteLine(Constants.StartWordRequest); 
 consoleControler.SetFirstWord(Console.ReadLine() ?? string.Empty);

Console.WriteLine(Constants.LastWordRequest); 
consoleControler.SetLastWord(Console.ReadLine() ?? string.Empty);

Console.WriteLine(Constants.AnswerFileRequest);
var resultsfile = Console.ReadLine();

var results = consoleControler.GetLadders().Reverse().ToList();
if (results.Count > 0)
    await File.WriteAllLinesAsync(Environment.CurrentDirectory + "\\" + resultsfile, results[0]);
