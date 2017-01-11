using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class PlayerRanking
    {
        static void Main(string[] args)
        {
            var result = new StringBuilder();

            var playersByType = new Dictionary<string, List<Player>>();
            var playersByPosition = new List<Player>();

            while (true)
            {
                string[] commandLine = Console.ReadLine().Split(' ').ToArray();

                var command = commandLine[0];
                if (command == "end")
                {
                    break;
                }

                if (command == "add")
                {
                    var player = new Player(commandLine[1], commandLine[2], int.Parse(commandLine[3]), int.Parse(commandLine[4]));

                    if (playersByType.ContainsKey(commandLine[2]))
                    {
                        playersByType[commandLine[2]].Add(player);
                    }
                    else
                    {
                        playersByType.Add(commandLine[2], new List<Player>());
                        playersByType[commandLine[2]].Add(player);
                    }
                    playersByPosition.Insert(int.Parse(commandLine[4]) - 1, player);

                    result.AppendLine(string.Format("Added player {0} to position {1}", commandLine[1], commandLine[4]));
                }
                else if (command == "find")
                {
                    if (playersByType.ContainsKey(commandLine[1]))
                    {
                        var players = playersByType[commandLine[1]].OrderBy(x => x.Name).ThenByDescending(x => x.Age).Take(5);
                        result.AppendLine(string.Format("Type {0}: {1}", commandLine[1], string.Join("; ", players)));
                    }
                    else
                    {
                        result.AppendLine(string.Format("Type {0}: ", commandLine[1]));
                    }
                }
                else if (command == "ranklist")
                {
                    var start = int.Parse(commandLine[1]);
                    var end = int.Parse(commandLine[2]);
                    for (int i = start - 1; i < end; i++)
                    {
                        if (i == (end - 1))
                        {
                            result.Append(string.Format("{0}. {1}", i + 1, playersByPosition[i]));
                        }
                        else
                        {
                            result.Append(string.Format("{0}. {1}; ", i + 1, playersByPosition[i]));
                        }
                    }
                    result.AppendLine();
                }
            }

            Console.WriteLine(result.ToString().TrimEnd());
        }
    }

    class Player : IComparable<Player>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public int Position { get; set; }

        public Player(string name, string type, int age, int position)
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
            this.Position = position;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
        }

        public int CompareTo(Player other)
        {
            var result = this.Position.CompareTo(other.Position);
            //var result = this.Name.CompareTo(other.Name);
            //if (result == 0)
            //{
            //    result = this.Age.CompareTo(other.Age) * -1;
            //}

            return result;
        }
    }
}
