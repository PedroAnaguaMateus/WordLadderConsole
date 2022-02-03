# WordLadderConsole
WordLadderConsole

Solution can work with more than 4 letters :)

Designed whth tests.

Some reuseble code.


.Net 6.0

File interaction separated. Built to read/write async.

Value container(Model) separated.

Controller separated.

WordLadder Engine calculator separated.  I could have done with webService and Json, but this was made between work and family time.

Tests done.


After some investigation i crossed this site: https://leetcode.com/problems/word-ladder/solution/
And after that i stumbled on this, and when i saw the fastest and memory optimized solution:
C# BFS Solution, faster than 94% and less than 100% memory
https://leetcode.com/problems/word-ladder-ii/discuss/375730/C-BFS-Solution-faster-than-94-and-less-than-100-memory

My second atempt was to get only words with the same length as the first one, starting or ending with the given first and last chars of begin and ending words

After that i will try to change a char in the begin word and see if it exists in the dictonary.. Saving all existing words and jumps in a List of Lists :)
This will be done recursevly until get last word.

After that i will get the first list in alphabetical order.


