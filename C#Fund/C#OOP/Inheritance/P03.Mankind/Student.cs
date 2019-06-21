using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName,string lastName,string facultyNumber)
            :base(firstName,lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => this.facultyNumber;
            private set
            {
                if (value.Any(a => !char.IsLetterOrDigit(a)) || value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"First Name: {this.FirstName}");
            builder.AppendLine($"Last Name: {this.LastName}");
            builder.AppendLine($"Faculty number: {this.facultyNumber}");

            return builder.ToString();
        }
    }
}


