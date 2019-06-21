using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestJournal3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> JournalQuests = Console.ReadLine()
                .Split(',',' ')
                .ToList();

            while(true)
            {
                string Input = Console.ReadLine();

                if(Input=="Retire!")
                {
                    break;
                }

                string[] tokens = Input.Split();


                string command = tokens[0];

                if(command=="Start")
                {
                    string quest = tokens[2];
                    
                    if (JournalQuests.Contains(quest))
                    {
                        
                        continue;
                    }
                    string lastItem = tokens.Last();
                    JournalQuests.Add(quest);
                    JournalQuests.Add(lastItem);


                }

                else if(command=="Complete")
                {
                    string quest = tokens[2];
                    string lastItem = tokens.Last();
                    
                    if (JournalQuests.Contains(quest))
                    {
                        JournalQuests.Remove(quest);
                        JournalQuests.Remove(lastItem);

                       
                    }
                    

                }

                else if(command=="Side")
                {
                    string quest = tokens[3];
                    string LastItem = tokens.Last();
                    
                    if(JournalQuests.Contains(quest))
                    {
                        JournalQuests.Remove(LastItem);
                    }
                }

                else if(command=="Renew")
                {
                    string quest = tokens[2];
                    string lastItem = tokens.Last();

                    if (JournalQuests.Contains(quest))
                    {
                        JournalQuests.Remove(quest);
                        JournalQuests.Remove(lastItem);
                        JournalQuests.Add(quest);
                        JournalQuests.Add(lastItem);
                    }
                }


            }
            
            Console.WriteLine(string.Join(", ",JournalQuests));
        }
    }
}
