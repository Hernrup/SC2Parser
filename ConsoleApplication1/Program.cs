using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcraft2.ReplayParser;
using Starcraft2.ReplayParser.Lime;

namespace Starcraft2.ReplayParser.Lime.Test

{
    class Program
    {
        static void Main(string[] args)
        {
            LimeSC2Parser p = new LimeSC2Parser();

            ReplayParser.Replay replay = p.parse("D:\\dev\\sc2data\\test.SC2Replay");

            foreach (var player in replay.Players)
            {
                if (player != null)
                {
                    if (player.IsWinner)
                    {
                        Console.Out.Write("*");
                    }

                    Console.Out.Write(player.Name + " ");
                }
            }

            Console.Out.WriteLine();

            Console.WriteLine("Press enter to quit.");
            Console.ReadLine();
        }
    }
}

