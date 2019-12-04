namespace Repository
{
    using System.Collections.Generic;

    public class Repository
    {
        private Dictionary<int, Person> people;
        private int id = 0;

        public Repository()
        {
            this.people = new Dictionary<int, Person>();
            this.id = 0;
        }

        public int Count => this.people.Count;

        public void Add(Person person)
        {
            this.people.Add(this.id, person);
            this.id++;
        }

        public Person Get(int id)
        {
            foreach (var kvp in people)
            {
                if (kvp.Key == id)
                {
                    return kvp.Value;
                }
            }

            return null;
        }

        public bool Update(int id, Person newPerson)
        {
            if (people.ContainsKey(id))
            {
                people[id] = newPerson;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            if (people.ContainsKey(id))
            {
                people.Remove(id);
                return true;
            }
            return false;
        }
    }
}
