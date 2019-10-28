using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class CoolLinkedList
    {
        public CoolNode Head { get; private set; }
        public CoolNode Tail { get; private set; }

        public int Count { get; private set; }

        public void AddHead(object value)
        {
            var newNode = new CoolNode(value);

            if(this.Count == 0)
            {
                this.Head = this.Tail = newNode;
            }
            else
            {
                var oldHead = this.Head;
                oldHead.Previous = newNode;
                newNode.Next = oldHead;
                this.Head = newNode;
            }

            this.Count++;
        }

        public void AddTail(object value)
        {
            var newNode = new CoolNode(value);

            if(this.Count == 0)
            {
                this.Head = this.Tail = newNode;
            }
            else
            {
                var oldTail = this.Tail;
                oldTail.Next = newNode;
                newNode.Previous = oldTail;
                this.Tail = newNode;
            }

            this.Count++;
        }

        public object RemoveHead()
        {
            this.ValidateIfListIsEmpty();

            var value = this.Head.Value;


            if (this.Head == this.Tail)
            {
                this.Head = null;
                this.Tail = null;
            }
            else
            {
                var newHead = this.Head.Next;
                newHead.Previous = null;
                this.Head.Next = null;
                this.Head = newHead;
            }

            this.Count--;

            return value;
        }

        public object RemoveTail()
        {
            this.ValidateIfListIsEmpty();

            var value = this.Tail.Value;

            if(this.Head == this.Tail)
            {
                this.Head = null;
                this.Tail = null;
            }
            else
            {
                var newTail = this.Tail.Previous;
                this.Tail.Previous = null;
                newTail.Next = null;
                this.Tail = newTail;
            }

            this.Count--;
            return value;
        }

        public void Remove(object value)
        {
            var currentNode = this.Head;

            while (currentNode != null)
            {
                var nodeValue = currentNode.Value;

                if(nodeValue.Equals(value))
                {
                    this.Count--;

                    var prevNode = currentNode.Previous;
                    var nextNode = currentNode.Next;

                    if (prevNode != null)
                    {
                        prevNode.Next = nextNode;
                    }

                    if(nextNode != null)
                    {
                        nextNode.Previous = prevNode;
                    }

                    if(this.Head == currentNode)
                    {
                        this.Head = nextNode;
                    }

                    if(this.Tail == currentNode)
                    {
                        this.Tail = prevNode;
                    }
                }

                currentNode = currentNode.Next;
            }
        }

        public void ForEach(Action<object> action)
        {
            var currentNode = this.Head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public object[] ToArray()
        {
            var arr = new object[this.Count];

            var currentNode = this.Head;
            var index = 0;

            while (currentNode != null)
            {
                arr[index] = currentNode.Value;
                index++;
                currentNode = currentNode.Next;
            }

            return arr;
        }

        private void ValidateIfListIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("LinkedList is empty");
            }
        }
    }
}
