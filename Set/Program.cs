using System;

namespace Set
{
    class Program
    {
        static void Main(string[] args)
        {
            Set<int> set = new Set<int>();

            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(6);

            Set<int> set2 = new Set<int>();

            set2.Add(1);
            set2.Add(4);
            set2.Add(5);
            set2.Add(6);

            Set<int> set3 = (Set<int>)Set.Set<int>.Intersection(set, set2);

            foreach(var i in set3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
