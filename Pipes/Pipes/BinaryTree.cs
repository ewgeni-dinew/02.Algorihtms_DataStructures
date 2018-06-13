using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipes
{
    class BinaryTree
    {
        public BinaryTreeElement Root { get; private set; }
        public ICollection<BinaryTreeElement> MatchCollection { get; private set; }

        private ICollection<BinaryTreeElement> elements;
        private BinaryTreeElement current;

        public BinaryTree()
        {
            this.Root = null;
            this.elements = new List<BinaryTreeElement>();
            this.MatchCollection = new List<BinaryTreeElement>();
        }

        private bool IsEmpty()
        {
            return this.Root == null;
        }

        public void Insert(int number, double value)
        {
            if (IsEmpty())
            {
                this.Root = new BinaryTreeElement(number, value);
                this.elements.Add(this.Root);
            }
            else
            {
                if (this.current.Left == null)
                {
                    this.current.SetLeftElement(new BinaryTreeElement(number, value));
                    this.elements.Add(this.current.Left);
                }
                else if (this.current.Right == null)
                {
                    this.current.SetRightElement(new BinaryTreeElement(number, value));
                    this.elements.Add(this.current.Right);
                }
            }
        }

        public BinaryTreeElement FindElement(int number)
        {
            this.current=this.elements.FirstOrDefault(x => x.Number.Equals(number));
            return current;
        }
        
        public void Traverse(BinaryTreeElement element)
        {
            if (element.HasNext())
            {
                Traverse(element.Left);
                Traverse(element.Right);
            }
            else
            {
                this.MatchCollection.Add(element);
                return;
            }
        }
    }
}
