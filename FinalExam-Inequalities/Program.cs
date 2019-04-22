using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FinalExam_Inequalities
{
    class Program
    {
        static void Main(string[] args)
        {
            var path_sample = @"C:\Users\evgeni.d\Desktop\inequalities.in.txt";
            var path_laptop = @"C:\Users\Evgeni\Downloads\inequalities.in.txt";

            //input path
            Console.Write("Input path to file: ");
            var path = Console.ReadLine();

            //read all lines from the document and insert them into a collection
            var lines = ReadFileLines(path_laptop);

            //finds the number that fits most of the expressions
            var mostCommonMatchingNum = FindCommonNumber(lines);

            //collect the expressions fitting the num
            var fittingExpressions = GetFittingExpressionsByNumber(mostCommonMatchingNum, lines);

            //print end result as per given task
            PrintResult(fittingExpressions);
        }

        private static void PrintResult(List<string> lines)
        {
            Console.WriteLine(lines.Count);

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        private static List<string> GetFittingExpressionsByNumber(int mostCommonMatchingNum, List<List<string>> lines)
        {
            var fittingExpressions = new List<string>();

            foreach (var line in lines)
            {
                if (LineIsValidWithGivenNum(line, mostCommonMatchingNum))
                {
                    fittingExpressions.Add(string.Join(" ", line));
                }
            }

            return fittingExpressions;
        }

        private static bool LineIsValidWithGivenNum(List<string> line, int num)
        {
            var operation = line[1];
            var expressionNumber = int.Parse(line[2]);
            var leftArrow = "<";
            var rightArrow = ">";
            var equalsSign = "=";

            if (operation.Contains(leftArrow))
            {
                if (operation.Contains(equalsSign))
                {
                    return num <= expressionNumber;
                }
                else
                {
                    return num < expressionNumber;
                }
            }
            else if (operation.Contains(rightArrow))
            {
                if (operation.Contains(equalsSign))
                {
                    return num >= expressionNumber;
                }
                else
                {
                    return num > expressionNumber;
                }
            }
            else if (operation.Equals(equalsSign))
            {
                return expressionNumber == num;
            }
            else
            {
                throw new ArgumentException("Invalid expression!");
            }
        }

        private static int FindCommonNumber(List<List<string>> lines)
        {
            //dictionary: key-digit; value-number of appearances
            var map = new Dictionary<int, int>();

            for (int i = 0; i <= lines.Count - 2; i++)
            {
                var upperOperation = lines[i][1];
                var upperNum = int.Parse(lines[i][2]);

                if (upperOperation.Equals("="))
                {
                    MarkNumberAppearance(map, upperNum);
                    continue;
                }

                for (int j = i + 1; j <= lines.Count - 1; j++)
                {
                    var lowerOperation = lines[j][1];
                    var lowerNum = int.Parse(lines[j][2]);

                    ExamineExpressions(upperOperation, upperNum, lowerOperation, lowerNum, map);
                }
            }

            return map.OrderByDescending(x => x.Value)
                .FirstOrDefault()
                .Key;
        }

        private static void IsOperationEquals(string upperOperation, int upperNum, Dictionary<int, int> map)
        {
            
        }

        private static void ExamineExpressions(string upperOperation, int upperNum, string lowerOperation, int lowerNum, Dictionary<int, int> map)
        {
            var leftArrow = "<";
            var rightArrow = ">";
            var equalsSign = "=";

            if (upperOperation.Contains(rightArrow) && lowerOperation.Contains(leftArrow))
            {
                if (upperOperation.Contains(equalsSign) && lowerOperation.Contains(equalsSign) && upperNum <= lowerNum)
                {
                    for (int n = upperNum; n <= lowerNum; n++)
                    {
                        MarkNumberAppearance(map, n);
                    }
                }
                else if (upperOperation.Contains(equalsSign) && upperNum < lowerNum)
                {
                    for (int n = upperNum; n < lowerNum; n++)
                    {
                        MarkNumberAppearance(map, n);
                    }
                }
                else if (lowerOperation.Contains(equalsSign) && upperNum <= lowerNum)
                {
                    for (int n = upperNum + 1; n <= lowerNum; n++)
                    {
                        MarkNumberAppearance(map, n);
                    }
                }
                else if (upperNum < lowerNum)
                {
                    for (int n = upperNum + 1; n < lowerNum; n++)
                    {
                        MarkNumberAppearance(map, n);
                    }
                }
            }
            else if (upperOperation.Contains(leftArrow) && lowerOperation.Contains(rightArrow))
            {
                if (upperOperation.Contains(equalsSign) && lowerOperation.Contains(equalsSign) && upperNum >= lowerNum)
                {
                    for (int n = lowerNum; n <= upperNum; n++)
                    {
                        MarkNumberAppearance(map, n);
                    }
                }
                else if (upperOperation.Contains(equalsSign) && upperNum > lowerNum)
                {
                    for (int n = lowerNum + 1; n <= upperNum; n++)
                    {
                        MarkNumberAppearance(map, n);
                    }
                }
                else if (lowerOperation.Contains(equalsSign) && upperNum > lowerNum)
                {
                    for (int n = lowerNum; n < upperNum; n++)
                    {
                        MarkNumberAppearance(map, n);
                    }
                }
                else if (upperNum > lowerNum)
                {
                    for (int n = lowerNum + 1; n < upperNum; n++)
                    {
                        MarkNumberAppearance(map, n);
                    }
                }
            }
        }

        private static List<List<string>> ReadFileLines(string path)
        {
            var lines = new List<List<string>>();

            var line = string.Empty;

            using (var file = new StreamReader(path))
            {
                while ((line = file.ReadLine()) != null)
                {
                    var tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    if (tokens.Any())
                    {
                        lines.Add(tokens);
                    }
                }
            }            

            return lines;
        }

        private static void MarkNumberAppearance(Dictionary<int, int> map, int key)
        {
            if (!map.ContainsKey(key))
            {
                map[key] = 0;
            }
            map[key]++;
        }
    }
}
