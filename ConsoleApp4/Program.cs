
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;


namespace Project2KevinArnoldWobble
{

    public class Program
    {

        public Dictionary<string, string[]> Buildpossible(string[] lines)
        {


            Dictionary<string, string[]> rad = new Dictionary<string, string[]>();
            if (lines.Length == 0)
            {
                System.Console.WriteLine("Sequence file is empty");
                return rad;
            }
            Dictionary<char, string> wobbledict = new Dictionary<char, string>()
            {
                ['A'] = "WR",
                ['T'] = "YW",
                ['C'] = "YS",
                ['G'] = "RS"
            };
            string seqnum = "";
            foreach (string line in lines)
            {
                if (!line.Contains("sequence", StringComparison.OrdinalIgnoreCase))
                {

                    rad[line] = (from a in wobbledict[line[line.Length - 2]]
                                 from b in wobbledict[line[line.Length - 1]]
                                 select line.Remove(line.Length - 2) + a + b).ToArray();
                }
                else
                {
                    seqnum = line;
                }
            }
            return rad;


        }

        public static void Main(string[] args)
        {

            if (args.Length < 2)
            {
                return;
            }
            var path = args[0];
            var res = args[1];

            string[] lines = File.ReadAllLines(path);
            Program prog = new Program();
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText("sequences.json", JsonSerializer.Serialize(prog.Buildpossible(lines), options));
        }


    }
}
