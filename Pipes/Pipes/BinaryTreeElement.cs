using System;
using System.Collections.Generic;
using System.Text;

namespace Pipes
{
    class BinaryTreeElement
    {
        public int Number { get; private set; }
        public double Value { get; private set; }
        public BinaryTreeElement Left { get; private set; }
        public BinaryTreeElement Right { get; private set; }

        public BinaryTreeElement(int number, double value)
        {
            this.Number = number;
            this.Value = value;
            this.Right = null;
            this.Left = null;
        }

        public bool HasNext()
        {
            return this.Left != null && this.Right != null;
        }

        public void SetRightElement(BinaryTreeElement right)
        {
            this.Right = right;
        }

        public void SetLeftElement(BinaryTreeElement left)
        {
            this.Left = left;
        }
    }
}
