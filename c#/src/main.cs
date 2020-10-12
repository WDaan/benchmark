using System;
using System.Collections.Generic;
using System.Linq;

namespace Main
{
    class Occurence
    {
        private int num { get; set; }
        private int count { get; set; }

        public Occurence(int num, int count)
        {
            this.num = num;
            this.count = count;
        }
    }

    class Index
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText("data.txt");

            List<string> parts = new List<string>(text.Split('\n'));
            List<int> numbers = parts.Select(s => int.Parse(s)).ToList();

            var g = numbers.GroupBy(i => i);

            List<Occurence> occurences = new List<Occurence>();

            foreach (var grp in g)
            {
                occurences.Add(new Occurence(grp.Key, grp.Count()));
            }

            //Console.WriteLine("[{0}]", string.Join(", ", occurence));
        }
    }
}