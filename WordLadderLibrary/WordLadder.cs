using System.Text;

namespace WordLadderLibrary
{
    public class WordLadder : IWordLadder
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            Dictionary<string, HashSet<string>> graph = new();
            AddWordToGraph(beginWord, graph);
            foreach (var word in wordList)
                AddWordToGraph(word, graph);

            //Queue For BFS
            Queue<string> queue = new();
            //Dictionary to store shortest paths to a word
            Dictionary<string, IList<IList<string>>> paths = new();

            queue.Enqueue(beginWord);
            paths[beginWord] = new List<IList<string>>() { new List<string>() { beginWord } };

            HashSet<string> visited = new();

            while (queue.Count > 0)
            {

                var stopWord = queue.Dequeue();
                //we can terminate loop once we reached the endWord as all paths leads here already visited in previous level 
                if (stopWord.Equals(endWord))
                {
                    return paths[endWord];
                }
                else
                {
                    if (visited.Contains(stopWord))
                        continue;

                    visited.Add(stopWord);

                    //Transform word to intermidiate words and find matches
                    for (int i = 0; i < stopWord.Length; i++)
                    {

                        StringBuilder sb = new(stopWord);
                        sb[i] = '*';
                        var transform = sb.ToString();

                        if (graph.ContainsKey(transform))
                        {

                            //Iterating all adj words
                            foreach (var word in graph[transform])
                            {
                                if (!visited.Contains(word))
                                {
                                    //fetch all paths leads current word to generate paths to adj/child node 
                                    foreach (var path in paths[stopWord])
                                    {

                                        var newPath = new List<string>(path)
                                        {
                                            word
                                        };

                                        if (!paths.ContainsKey(word))
                                            paths[word] = new List<IList<string>>() { newPath };
                                        else if (paths[word][0].Count >= newPath.Count)// we are interested in shortest paths only
                                            paths[word].Add(newPath);
                                    }
                                    queue.Enqueue(word);
                                }
                            }
                        }
                    }
                }

            }
            return new List<IList<string>>();
        }

        //For example word hit can be written as *it,h*t,hi*. 
        //This method genereates a map from each intermediate word to possible words from our wordlist
        private void AddWordToGraph(string word, Dictionary<string, HashSet<string>> graph)
        {

            for (int i = 0; i < word.Length; i++)
            {
                StringBuilder sb = new StringBuilder(word);
                sb[i] = '*';

                if (graph.ContainsKey(sb.ToString()))
                    graph[sb.ToString()].Add(word);
                else
                {
                    var set = new HashSet<string>();
                    set.Add(word);
                    graph[sb.ToString()] = set;
                }
            }
        }
    }
}