﻿namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public DoublyLinkedList()
        {
            this.head = this.tail = null;
            this.Count = 0;
        }

        public DoublyLinkedList(Node<T> head)
        {
            this.head = this.tail = head;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> toInsert = new Node<T>
            { 
                Item = item,
            };

            if (this.Count == 0)
            {
                this.head = this.tail = toInsert;
            }
            else
            {
                this.head.Previous = toInsert;
                toInsert.Next = this.head;
                this.head = toInsert;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            Node<T> toInsert = new Node<T>
            { 
                Item = item
            };

            if (this.Count == 0)
            {
                this.head = this.tail = toInsert;
            }
            else
            {
                toInsert.Previous = this.tail;
                this.tail.Next = toInsert;
                this.tail = toInsert;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.EnsureNotEmpty();

            return this.head.Item;
        }

        public T GetLast()
        {
            this.EnsureNotEmpty();

            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();

            Node<T> current = this.head;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                Node<T> newHead = this.head.Next;
                newHead.Previous = null;
                this.head = newHead;
            }

            this.Count--;

            return current.Item;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();

            Node<T> current = this.tail;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                Node<T> newTail = this.tail.Previous;
                newTail.Next = null;
                this.tail = newTail;
            }

            this.Count--;

            return current.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}