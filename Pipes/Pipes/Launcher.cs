using System;
using System.Collections.Generic;
using System.Linq;

namespace Pipes
{
    class Launcher
    {
        static void Main()
        {
            var totalLiters = double.Parse(Console.ReadLine());
            var totalElements = int.Parse(Console.ReadLine());

            var tree = new BinaryTree();
            tree.Insert(1, totalLiters);

            for (int i = 1; i < totalElements; i += 2)
            {
                var line = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var pipeNumber = line[0];
                var currentElement = tree.FindElement(pipeNumber);

                var pipeLeftHeirNumber = line[1];
                var pipeLeftHeirValue = line[2] / 100.0 * currentElement.Value;
                var pipeRightHeirNumber = line[3];
                var pipeRightHeirValue = line[4] / 100.0 * currentElement.Value;

                tree.Insert(pipeLeftHeirNumber, pipeLeftHeirValue);
                tree.Insert(pipeRightHeirNumber, pipeRightHeirValue);
            }

            tree.Traverse(tree.Root);
            Console.WriteLine("Result: ");

            foreach (var element in tree.MatchCollection)
            {
                Console.WriteLine($"{element.Number} {element.Value:f2}");
            }
        }
    }
}
