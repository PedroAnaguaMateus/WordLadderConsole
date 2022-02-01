using WordLadderConsole;

string GetConsoleLineAnswer(string question)
{
    Console.WriteLine(question);
    return Console.ReadLine() ?? string.Empty;
}


#region main
ConsoleController consoleControler; 
Filehandler filehandler = new();
List<string> allwords = new();
string firstWord, lastWord, resultsfile;

await filehandler.GetAllWordsFromFile(allwords, GetConsoleLineAnswer(Constants.DictonaryFileRequest));

firstWord = GetConsoleLineAnswer(Constants.StartWordRequest);
lastWord = GetConsoleLineAnswer(Constants.LastWordRequest);
resultsfile = GetConsoleLineAnswer(Constants.AnswerFileRequest);

consoleControler = new ConsoleController(firstWord, lastWord, allwords);
var results = consoleControler.GetLadders();

if (results.Count > 0)
    await filehandler.WriteLadderToFile(resultsfile, results[0].ToList<string>());

#endregion