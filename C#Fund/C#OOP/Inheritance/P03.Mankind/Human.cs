using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Mankind
{
    public class Human
    {
        private const int MinFirstNameLength = 4;
        private const int MinLastNameLength = 3;

        private string firstName;
        private string lastName;

        public Human(string firstName,string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                this.CheckFirstLetterIsUpper(value, nameof(this.firstName));

                this.ValidateLenght(value, MinFirstNameLength, nameof(this.firstName));

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            private set
            {
                this.CheckFirstLetterIsUpper(value, nameof(this.lastName));

                this.ValidateLenght(value, MinLastNameLength, nameof(this.lastName));

                this.lastName = value;
            }
        }

        private void CheckFirstLetterIsUpper(string value, string parameterName)
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {parameterName}");
            }
        }

        private void ValidateLenght(string value, int validLength, string parameterName)
        {
            if (value.Length < 4)
            {
                throw new ArgumentException($"Expected length at least {validLength} symbols! Argument: {parameterName}");
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"First Name: {this.FirstName}");
            builder.AppendLine($"Last Name: {this.LastName}");
            return builder.ToString().TrimEnd();
        }
    }
}
