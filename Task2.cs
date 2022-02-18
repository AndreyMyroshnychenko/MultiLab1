using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    class Task2
    {
        static void Main(string[] args)
        {
            string readingText = File.ReadAllText(@"..\..\..\..\..\task2.txt");
            int iterator = 0;
            string readingWord = "";
            bool mustBe;
            int textLength = readingText.Length;
            string[] words = new string[100000];
            string[,] wordsOnPages = new string[10000, 10000];
            int pages = 0;
            int wordCount = 0;
            int rows = 0;
            int wordsOnPageCount = 0;

            whileImitation:
            if (readingText[iterator] >= 65 && readingText[iterator] <= 90 || readingText[iterator] >= 97 && readingText[iterator] <= 122 ||
                readingText[iterator] == 45 || readingText[iterator] == 225 || readingText[iterator] == 234 || readingText[iterator] == 224)
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
                if (readingText[iterator] == '\n')
                {
                    rows++;

                }

                if (rows > 45)
                {
                    pages++;
                    wordsOnPageCount = 0;
                    rows = 0;
                }

                if (readingWord != "" && readingWord != null && readingWord != "-" && readingWord != "no" && readingWord != "from"
                    && readingWord != "the" && readingWord != "by" && readingWord != "and" && readingWord != "i"
                    && readingWord != "in" && readingWord != "or" && readingWord != "any" && readingWord != "for"
                    && readingWord != "to" && readingWord != "\"" && readingWord != "a" && readingWord != "on"
                    && readingWord != "of" && readingWord != "at" && readingWord != "is" && readingWord != "\n"
                    && readingWord != "\r" && readingWord != "\r\n" && readingWord != "\n\r")
                {
                    words[wordCount] = readingWord;
                    wordCount++;
                    wordsOnPages[pages, wordsOnPageCount] = readingWord;
                    wordsOnPageCount++;
                }

                readingWord = "";

            }

            iterator++;

            if (iterator < textLength)
            {
                goto whileImitation;
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
            }

            int[] wordsSeenOnceCount = new int[100000];
            string[] wordsSeenOnce = new string[100000];


            int wordsAmount = words.Length;
            iterator = 0;
            int j;
            int positionInsert;
            int duplicates = 0;

        whileCountImitation:
            positionInsert = 0;
            int lengthNow = wordsSeenOnce.Length;
            j = 0;
            mustBe = true;

            forImitation:
            if (wordsSeenOnce[j] != null && j < lengthNow)
            {
                if (wordsSeenOnce[j] == words[iterator])
                {
                    positionInsert = 1;
                    mustBe = false;
                    goto endForImitation;
                }
                j++;
                goto forImitation;
            }

            endForImitation:
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
            if(words[iterator] != null && iterator < wordsAmount)
            {
                goto whileCountImitation;
            }


            int length = wordsSeenOnceCount.Length;
            int a = 0;
            string[] wordLess100Times=new string[100000];
            int lastWordInsert = 0;
            Less100Times:
            if (wordsSeenOnce[a] != null && a < length)
            {
                if (wordsSeenOnceCount[a] <= 100)
                {
                    wordLess100Times[lastWordInsert] = wordsSeenOnce[a];
                    lastWordInsert++;
                }
                a++;
                goto Less100Times;
            }

            int sorted;
            int count;
            bool swapWord;
            int wordWritten = 0;
            int currentWordLength;
            int nextWordLength;

            firstSortImitation:

            if (wordLess100Times[wordWritten] != null && wordWritten < wordLess100Times.Length)
            {
                sorted = 0;
                secondSortImitation:

                if (wordLess100Times[sorted+1] != null && sorted < wordLess100Times.Length - wordWritten - 1)
                {
                    currentWordLength = wordLess100Times[sorted].Length;
                    nextWordLength = wordLess100Times[sorted + 1].Length;

                    int wordLengthComparison;

                    if (nextWordLength < currentWordLength)
                    {
                        wordLengthComparison = nextWordLength;

                    }
                    else
                    {
                        wordLengthComparison = currentWordLength;
                    }

                    swapWord = false;
                    count = 0;

                    alphabetExamination:
                    if (wordLess100Times[sorted+1][count] < wordLess100Times[sorted][count])
                    {
                        swapWord = true;
                        goto alphabetEnd;

                    }

                    if (wordLess100Times[sorted + 1][count] > wordLess100Times[sorted][count])
                    {
                        goto alphabetEnd;
                    }

                    count++;
                    if (wordLengthComparison > count)
                    {
                        goto alphabetExamination;
                    }

                    alphabetEnd:
                    if (swapWord)
                    {
                        string temporaryWord = wordLess100Times[sorted];
                        wordLess100Times[sorted] = wordLess100Times[sorted + 1];
                        wordLess100Times[sorted + 1] = temporaryWord;
                    }

                    sorted++;
                    goto secondSortImitation;

                }

                wordWritten++;
                goto firstSortImitation;

            }

            a = 0;
            int wordLengthSeenLess100 = wordLess100Times.Length;

            print:
            if (wordLess100Times[a] != null && a < wordLengthSeenLess100)
            {
                Console.Write("{0} - ", wordLess100Times[a]);

                int dimensionOne = 0;
                int dimensionTwo;

                int[] pagesWithWords = new int[100];
                int insertIntoPage = 0;

                pageExamination:

                if (wordsOnPages[dimensionOne, 0] != null && dimensionOne < 10000)
                {
                    dimensionTwo = 0;

                    pageCheckOnWord:

                    if (wordsOnPages[dimensionOne, dimensionTwo] != null && dimensionTwo < 10000)
                    {

                        if (wordsOnPages[dimensionOne, dimensionTwo] == wordLess100Times[a])
                        {

                            pagesWithWords[insertIntoPage] = dimensionOne+1;
                            insertIntoPage++;
                            dimensionOne++;
                            goto pageExamination;

                        }

                        dimensionTwo++;
                        goto pageCheckOnWord;

                    }

                    dimensionOne++;
                    goto pageExamination;
                }

                int secondCount = 0;

                pagination:

                if (pagesWithWords[secondCount] !=0 && secondCount < 100)
                {

                    if (pagesWithWords[secondCount+1] != 0 && secondCount != 99)
                    {
                        Console.Write("{0}, ", pagesWithWords[secondCount]);
                    }
                    else
                    {
                        Console.Write("{0}, ", pagesWithWords[secondCount]);
                    }

                    secondCount++;
                    goto pagination;
                }

                Console.WriteLine("\n");
                a++;
                goto print;
            }
        }
    }
}
