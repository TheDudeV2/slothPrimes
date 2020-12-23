using System;

/*
 * PRIME NUMBERS
 * Version 1 - naive approach
 * ---------
 * 1) Determine all prime numbers from 2 to 1,000,000
 * 2) Display graph showing prime count for each 100,000 range
 * 
 * 
 * Version 2 - OOP and Eresthosthenes
 * ---------
 * 1) Determine all prime numbers from 2 to 10,000,000,000
 * 2) Display graph showing prime count for each 100,000 range
 *  
 * 
 */

namespace slothPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCandidate = 1000000;
            int bucketRange = 100000;
            int firstPrime = 3;

            int bucketBegin = 0;
            int bucketEnd = bucketBegin + bucketRange;
            int count = 0;

            int graphIndent = (maxCandidate.ToString().Length * 2) + 5;
            int graphWidth = 50;
            int bucketMax = bucketRange / 2;
            double graphScale = (double)graphWidth / (double)bucketMax;


            for (int candidate = firstPrime; candidate <= maxCandidate; candidate = candidate + 2)
            {
                //Console.WriteLine("checking candidate " + candidate);
                bool isPrime = true;

                int firstDivider = 3;
                for (int divider = firstDivider; divider < (candidate / 2); divider = divider + 2)
                {
                    //Console.WriteLine("  checking divider " + divider);
                    if ((candidate % divider) == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    //Console.WriteLine(candidate);
                    count++;
                }

                if (candidate > bucketEnd)
                {
                    //Console.WriteLine(bucketBegin + "-" + bucketEnd + ": " + count);
                    string bucketName = (bucketBegin + "-" + bucketEnd + ": ");
                    int numberOfSpaces = graphIndent - bucketName.Length;
                    String spaces = new String(' ', numberOfSpaces);
                    int numberOfEquals = (int)(count * graphScale);
                    String graphLine = new string('=', numberOfEquals);
                    Console.WriteLine(spaces + bucketName + graphLine);
                    
                    count = 0;
                    bucketBegin = bucketEnd + 1;
                    bucketEnd = bucketBegin + bucketRange - 1;
                }
                              
            }
            
        }
    }
}
