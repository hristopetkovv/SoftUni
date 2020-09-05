namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;

        public SinglyLinkedList()
        {
            this._head = null;
            this.Count = 0;
        }

        public SinglyLinkedList(Node<T> item)
        {
            this._head = item;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item, this._head);
            this._head = newNode;
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);
            Node<T> current = this._head;

            if (current == null)
            {
                this._head = newNode;
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }
            this.Count++;
        }

        public T GetFirst()
        {
            this.ValidateIfListIsNotEmpty();

            return this._head.Value;
        }

       

        public T GetLast()
        {
            this.ValidateIfListIsNotEmpty();
            Node<T> current = this._head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public T RemoveFirst()
        {
            this.ValidateIfListIsNotEmpty();

            Node<T> firstNode = this._head;

            this._head = this._head.Next;
            this.Count--;

            return firstNode.Value;
        }

        //public T RemoveLast()
        //{
        //    this.ValidateIfListIsNotEmpty();
        //}

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this._head;

            while (current != null)
            {
                yield return current.Value;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void ValidateIfListIsNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Linked list is empty!");
            }
        }
    }
}