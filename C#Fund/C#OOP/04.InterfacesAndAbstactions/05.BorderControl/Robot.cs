using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public class Robot : IIdentifiable
    {
        private string name;

        public Robot(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}
