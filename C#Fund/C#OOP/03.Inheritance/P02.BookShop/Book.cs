using System;
using System.Collections.Generic;
using System.Text;

namespace P02.BookShop
{
    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            private set
            {
                var authorNames = value
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var secondName = authorNames[1];

                if (char.IsDigit(secondName[0]))
                {
                    throw new ArgumentException("Author not valid!");
                }             

                this.author = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                if(value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                if(value <= 0 )
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;


        }
    }
}
