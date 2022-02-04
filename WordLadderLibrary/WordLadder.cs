using System.Text;

namespace WordLadderLibrary
{
    public class WordLadder : IWordLadder
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            List<IList<string>> ladders = new();
            if (!String.IsNullOrEmpty(beginWord) && !String.IsNullOrEmpty(endWord) && wordList.Count > 0)
                if(beginWord.Length == endWord.Length)
                {
                    List<IList<string>> laddersfirst = new List<IList<string>> ().Append(new List<string>().Append(beginWord).ToList()).ToList();
                    
                    ladders = AfterFirstInteractionLadder(endWord, wordList.ToList(), laddersfirst);
                    ladders = OrderLadders(ladders);
                }

            return ladders;
        }

        private static List<IList<string>> OrderLadders(List<IList<string>> ladders)
        {
            List<string> alfabelicalFirsList = new(ladders.First().ToList());
            bool firstFound = false;

            if (ladders.Count > 1)
            {
                List<string> firstladder = ladders.First().ToList();
                foreach (string word in firstladder)
                {
                    string wordToCompare = word;
                    foreach (List<string> ladder in ladders)
                    {
                        int index = firstladder.IndexOf(word);

                        if(index < ladder.Count)
                            if(wordToCompare.CompareTo(ladder.ElementAt(index)) > 0)
                            {
                                wordToCompare = ladder.ElementAt(index);
                                alfabelicalFirsList = new(ladder);
                                firstFound = true;
                            }
                    }

                    if (firstFound)
                        break;
                }  

            }
            return new List<IList<string>> { alfabelicalFirsList };
        }

        private List<IList<string>> AfterFirstInteractionLadder(string endWord, List<string> wordList, List<IList<string>> laddersfirst)
        {
            List<IList<string>> ladders = new(laddersfirst);

            while (!LadderFinished(endWord, ladders))
            {
                string word = String.Empty;
                foreach (List<string> ladder in laddersfirst)
                {
                    word = ladder.Last();
                    List<IList<string>> secondLadder = GetLadders(word, endWord, wordList.ToList());

                    if (secondLadder.Count == 0) // remove
                        ladders.Remove(ladder);
                    else
                    {
                        ladders.Remove(ladder);
                        foreach (List<string> ladder2 in secondLadder)
                            ladders.Add(ladder.Concat(ladder2).ToList());
                    }

                }

                laddersfirst = new(ladders);
            }
            return ladders;
        }

        private static bool LadderFinished(string endWord, List<IList<string>> ladders)
        {
            bool finish = false;

            foreach (List<string> ladder in ladders)
                if (endWord.Equals(ladder.Last()))
                    finish = true;

            return finish;
        }

        private List<IList<string>> GetLadders(string beginWord, string endWord, List<string> wordList)
        {
            List<IList<string>> ladders = new();
            StringBuilder sbBeginword = new(beginWord);
            StringBuilder sbEndWord = new(endWord);

            for (int charIndex = 0; charIndex < beginWord.Length; charIndex++)
            {
                if (!sbBeginword[charIndex].Equals(sbEndWord[charIndex]))
                {
                    StringBuilder sbBeginWordNew = GetPossibleNewWord(sbBeginword, sbEndWord, charIndex);

                    if (WordExistsInDictonary(sbBeginWordNew, wordList))
                        ladders.Add(new List<string>().Append(sbBeginWordNew.ToString()).ToList());
                }
            }

            return ladders;
        }

        private static bool WordExistsInDictonary(StringBuilder word, List<string> dictonary)
        {
            return dictonary.Contains(word.ToString());
        }

        private static StringBuilder GetPossibleNewWord(StringBuilder firstWord, StringBuilder secondWord, int charIndex)
        {
            StringBuilder newWord = new(firstWord.ToString());
            newWord[charIndex] = secondWord[charIndex];
            
            return newWord;
        }
    }
}