using P08.MilitaryElite.Models;
using P08.MilitaryElite.Models.Privates;
using P08.MilitaryElite.Models.Privates.SpecialisedSoldiers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>();
                    
            string soldier = Console.ReadLine();

            while (soldier != "End")
            {
                string[] soldierArgs = soldier.Split();

                string soldierType = soldierArgs[0];
                string id = soldierArgs[1];
                string firstName = soldierArgs[2];
                string lastName = soldierArgs[3];

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(soldierArgs[4]);

                    Private @private = new Private(id, firstName, lastName, salary);

                    soldiers.Add(@private);
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(soldierArgs[4]);

                    Spy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiers.Add(spy);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(soldierArgs[4]);

                    List<string> ids = soldierArgs.Skip(5).ToList();

                    List<Private> privates = GetPrivates(ids, soldiers);

                    LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary, privates);

                    soldiers.Add(general);
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(soldierArgs[4]);

                    string corps = soldierArgs[5];

                    List<string> repairArgs = soldierArgs.Skip(6).ToList();

                    List<Repair> repairs = GetRepairs(repairArgs);

                    try
                    {
                        Engineer general = new Engineer(id, firstName, lastName, salary, corps, repairs);
                        soldiers.Add(general);
                    }
                    catch (Exception)
                    {
                    }

                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(soldierArgs[4]);

                    string corps = soldierArgs[5];

                    List<string> missionArgs = soldierArgs.Skip(6).ToList();

                    List<Mission> missions = GetMissions(missionArgs);

                    try
                    {
                        Commando commando = new Commando(id, firstName, lastName, salary, corps, missions);
                        soldiers.Add(commando);
                    }
                    catch (Exception)
                    {
                    }

                }

                soldier = Console.ReadLine();
            }

            foreach (var soldierObject in soldiers)
            {
                Console.WriteLine(soldierObject);
            }

        }

        private static List<Mission> GetMissions(List<string> missionArgs)
        {
            List<Mission> missions = new List<Mission>();

            for (int i = 0; i < missionArgs.Count; i += 2)
            {
                string codeName = missionArgs[i];
                string state = missionArgs[i + 1];

                try
                {
                Mission mission = new Mission(codeName, state);
                missions.Add(mission);
                }
                catch (Exception)
                {
                }
            }

            return missions;
        }

        private static List<Repair> GetRepairs(List<string> repairArgs)
        {
            List<Repair> repairs = new List<Repair>();

            for (int i = 0; i < repairArgs.Count; i+=2)
            {
                string partName = repairArgs[i];
                int hoursWorked = int.Parse(repairArgs[i + 1]);

                Repair repair = new Repair(partName, hoursWorked);

                repairs.Add(repair);
            }

            return repairs;
        }

        private static List<Private> GetPrivates(List<string> ids, List<Soldier> soldiers)
        {   
            List<Private> privates = new List<Private>();

            List<Soldier> filteredSoldiers = soldiers
                .Where(x => x.GetType().Name == nameof(Private)).ToList();

            foreach (var privateSoldier in filteredSoldiers)
            {
                if (ids.Contains(privateSoldier.Id))
                {
                    privates.Add((Private)privateSoldier);
                }
            }

            return privates;
        }
    }
}
