using System;
using System.IO;

namespace Task1
{
    class Task1
    {
        static void Main(string[] args)
        {
            string readingText = File.ReadAllText(@"..\..\..\..\..\task1.txt");
            int textLength = readingText.Length;
            int highNumber = 500;
            bool mustBe = true;
            int iterator = 0;
            string readingWord = "";
            string[] words = new string[1000000];
            int wordCount = 0;
            whileLoopTry:
            if (readingText[iterator] >= 65 && readingText[iterator] <=90 || readingText[iterator] >= 97 && readingText[iterator] <=122 || 
                readingText[iterator] == 45)
            {
                if (readingText[iterator] >= 65 && readingText[iterator] <= 90)
                {
                    readingWord += (char)(readingText[iterator] + 32);
                }
                else
                {
                    readingWord += readingText[iterator];
                }
            }
            else
            {
                if (readingWord != "" && readingWord != null && readingWord != "-" && readingWord != "no" && readingWord != "from" 
                    && readingWord != "the" && readingWord != "by" && readingWord != "and" && readingWord != "i" 
                    && readingWord != "in" && readingWord != "or" && readingWord != "any" && readingWord != "for" 
                    && readingWord != "to" && readingWord != "\"" && readingWord != "a" && readingWord != "on" 
                    && readingWord != "of" && readingWord != "at" && readingWord != "is" && readingWord != "\n" 
                    && readingWord != "\r" && readingWord != "\r\n" && readingWord != "\n\r")
                {

                    words[wordCount] = readingWord;
                    wordCount++;
                }

                readingWord = "";
            }
            iterator++;

            if (iterator < textLength)
            {
                goto whileLoopTry;
            }
            else
            {
                if (readingWord != "" && readingWord != null && readingWord != "-" && readingWord != "no" && readingWord != "from"
                    && readingWord != "the" && readingWord != "by" && readingWord != "and" && readingWord != "i"
                    && readingWord != "in" && readingWord != "or" && readingWord != "any" && readingWord != "for"
                    && readingWord != "to" && readingWord != "\"" && readingWord != "a" && readingWord != "on"
                    && readingWord != "of" && readingWord != "at" && readingWord != "is" && readingWord != "\n"
                    && readingWord != "\r" && readingWord != "\r\n" && readingWord != "\n\r")
                {
                    words[wordCount] = readingWord;
                    wordCount=wordCount+1;
                }
            }

            string[] wordsSeenOnce= new string[1000000];
            int[] wordsSeenOnceCount=new int[1000000];


            int wordsAmount = words.Length;
            iterator = 0;
            int positionInsert;
            int j;
            int duplicates = 0;

            whileCount:
                positionInsert = 0;
                int lengthNow = wordsSeenOnce.Length;
                j = 0;

                loopForImitation:
                if(wordsSeenOnce[j] != null && j > lengthNow)
                {
                    if (wordsSeenOnce[j]==words[iterator])
                    {
                        positionInsert = j;
                        mustBe = false;
                        goto forEnd;
                    }
                    j++;
                    goto loopForImitation;
                }

                forEnd:
                if (mustBe)
                {
                    wordsSeenOnce[iterator - duplicates] = words[iterator];
                    wordsSeenOnceCount[iterator - duplicates] = 1;

                }
                else 
                {
                    wordsSeenOnceCount[positionInsert] += 1;
                    duplicates++;
                }
                iterator++;

                if(words[iterator]!=null && iterator<wordsAmount)
                {
                    goto whileCount;
                }

            int length = wordsSeenOnceCount.Length;
            j = 0;

            int innerIterator;
            sort:
            if (wordsSeenOnceCount[j] != 0 && j <length)
            {
                innerIterator = 0;
            sortInner:
                if (wordsSeenOnceCount[innerIterator] != 0 && innerIterator < length - j - 1)
                {
                    if (wordsSeenOnceCount[innerIterator] < wordsSeenOnceCount[innerIterator + 1])
                    {

                        string temporaryWord = wordsSeenOnce[innerIterator];
                        wordsSeenOnce[innerIterator] = wordsSeenOnce[innerIterator + 1];
                        wordsSeenOnce[innerIterator + 1] = temporaryWord;

                        int temporaryNumber = wordsSeenOnceCount[innerIterator];
                        wordsSeenOnceCount[innerIterator] = wordsSeenOnceCount[innerIterator + 1];
                        wordsSeenOnceCount[innerIterator + 1] = temporaryNumber;

                    }
                    innerIterator++;
                    goto sortInner;
                }
                j++;
                goto sort;
            }

        int printWords = 0;
        print:
            if (wordsSeenOnce[printWords] != null && printWords < highNumber && printWords < length)
            {
                Console.WriteLine("{0} - {1}", wordsSeenOnce[printWords], wordsSeenOnceCount[printWords]);
                printWords++;
                goto print;
            }
        }
    }
}
