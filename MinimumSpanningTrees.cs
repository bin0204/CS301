using System;
using System.Collections.Generic;

namespace MinimumSpanningTrees
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Sorts list of tuple instances
            //Create three item tuple
            List<Tuple<string, string, int>> list = new List<Tuple<string, string, int>>();
            list.Add(new Tuple<string, string, int>("b", "e", 2));
            list.Add(new Tuple<string, string, int>("a", "c", 3));
            list.Add(new Tuple<string, string, int>("e", "f", 3));
            list.Add(new Tuple<string, string, int>("b", "c", 4));
            list.Add(new Tuple<string, string, int>("f", "g", 4));
            list.Add(new Tuple<string, string, int>("a", "b", 5));
            list.Add(new Tuple<string, string, int>("c", "d", 5));
            list.Add(new Tuple<string, string, int>("e", "g", 5));
            list.Add(new Tuple<string, string, int>("b", "d", 6));
            list.Add(new Tuple<string, string, int>("c", "f", 6));
            list.Add(new Tuple<string, string, int>("d", "e", 6));
            list.Add(new Tuple<string, string, int>("d", "f", 6));

            //Return the sets by cost
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
            //make a nested list
            List<List<string>> eachNodeList = new List<List<string>>(){
                { new List<string> { "a" } },
                { new List<string> { "b" } },
                { new List<string> { "c" } },
                { new List<string> { "d" } },
                { new List<string> { "e" } },
                { new List<string> { "f" } },
                { new List<string> { "g" } }
            };

            for (int i = 0; i < eachNodeList.Count; i++)
            {
                Console.WriteLine("list:" + String.Join(",", eachNodeList[i]));
            }

            Console.WriteLine("Kruskal's Algorithms");

            int index1 = 0;
            int index2 = 0;
            int n = 7;

            // Kruskal's Algorithms
            for (int i = 0; i < list.Count; i++)
            {
                if (eachNodeList[0].Count == n)
                    break;
                String v = list[i].Item1;
                String u = list[i].Item2;

                for (int j = 0; j < eachNodeList.Count; j++)
                {
                    if (String.Join(",", eachNodeList[j]).Contains(u))
                    {
                        index1 = j;
                    }
                    if (String.Join(",", eachNodeList[j]).Contains(v))

                    {
                        index2 = j;
                    }

                }
                //Check indexes
                if (index1 != index2)
                {
                    foreach (var e in eachNodeList[index1])
                    {
                        eachNodeList[index2].Add(e);
                    }
                    eachNodeList.Remove(eachNodeList[index1]);
                }

                //Print out the
                foreach (List<string> s in eachNodeList)
                {
                    Console.Write("(" + String.Join(",", s) + ")");
                }
                Console.WriteLine("");
            }


            // Prim's Algorithms
            Console.WriteLine("Prim's Algorithms");
            Prims();

        }
		static void Prims()
		{
			List<Tuple<string, string, int>> allList = new List<Tuple<string, string, int>>();
            allList.Add(new Tuple<string, string, int>("b", "e", 2));
            allList.Add(new Tuple<string, string, int>("e", "b", 2));
            allList.Add(new Tuple<string, string, int>("a", "c", 3));
          	allList.Add(new Tuple<string, string, int>("e", "f", 3));
          	allList.Add(new Tuple<string, string, int>("c", "a", 3));
          	allList.Add(new Tuple<string, string, int>("f", "e", 3));
          	allList.Add(new Tuple<string, string, int>("b", "c", 4));
          	allList.Add(new Tuple<string, string, int>("f", "g", 4));
          	allList.Add(new Tuple<string, string, int>("c", "b", 4));
          	allList.Add(new Tuple<string, string, int>("g", "f", 4));
          	allList.Add(new Tuple<string, string, int>("a", "b", 5));
          	allList.Add(new Tuple<string, string, int>("c", "d", 5));
          	allList.Add(new Tuple<string, string, int>("e", "g", 5));
          	allList.Add(new Tuple<string, string, int>("b", "a", 5));
          	allList.Add(new Tuple<string, string, int>("d", "c", 5));
          	allList.Add(new Tuple<string, string, int>("g", "e", 5));
          	allList.Add(new Tuple<string, string, int>("b", "d", 6));
          	allList.Add(new Tuple<string, string, int>("c", "f", 6));
          	allList.Add(new Tuple<string, string, int>("d", "e", 6));
          	allList.Add(new Tuple<string, string, int>("d", "f", 6));
          	allList.Add(new Tuple<string, string, int>("d", "b", 6));
          	allList.Add(new Tuple<string, string, int>("f", "c", 6));
          	allList.Add(new Tuple<string, string, int>("e", "d", 6));
          	allList.Add(new Tuple<string, string, int>("f", "d", 6));

            List<String> v = new List<string>();
            List<Tuple<String, String, int>> ve = new List<Tuple<string, string, int>>();

            //set the start node
            v.Add("a");
            int cost = 0;
            while (v.Count < 7)
            {
                Console.WriteLine("{ " + String.Join(", ", v) + " }");
                string Add;
                int currentCost = 0;
				        List<Tuple<String, String, int>> currentList2 = new List<Tuple<string, string, int>>();
                foreach (String s in v)
                {
                    List<Tuple<String, String, int>> KS = returns(allList, s);
                    List<Tuple<String, String, int>> next = new List<Tuple<string, string, int>>findShort(KS, v);

                    if (currentCost == 0)
                    {
                        currentCost = next.Item3;
                        currentList2 = next;
                    }
                    else if (currentCost > next.Item3)
                    {
                        currentCost = next.Item3;
                        currentList2 = next;
                    }
                    else if (currentCost == next.Item3)
                    {
                        if (!v.Contains(next.Item1) || !v.Contains(next.Item2))
                        {
                            currentCost = next.Item3;
                            currentList2 = next;
                        }
                    }
                }
                allList.Remove(currentList2.Item);
				      }
			}



		}
        static List<Tuple<string, string, int>> returns(List<Tuple<string, string, int>> TT, String s)
        {
            List<Tuple<string, string, int>> list2 = new List<Tuple<string, string, int>>();
            foreach(Tuple<string,string,int> i in TT)
            {
                if(i.Item1 == s)
                {
                    list2.Add(i);
                }
            }
            return list2;
        }

        static Tuple<string,string,int> findShort(List<Tuple<string, string, int>> l, List<string> list2)
        {
            if (l.Count == 1)
            {
                if (!list2.Contains(l[0].Item1) || (!list2.Contains(l[0].Item2)))
                {
                    return l[0];
                }
            }
            int shortest = 0;
            List<Tuple<string, string, int>> selected = new List<Tuple<string, string, int>>();
            int count = 0; // variable to count
            foreach (Tuple<string, string, int> i in l)
            {
                if (count == 0)
                {
                    shortest = i.Item3;
                    selected[0] = i;
                }
                else
                {
                    if (!list2.Contains(i.Item1) && !list2.Contains(i.Item2))
                    {
                        if (shortest > i.Item3)
                        {
                            shortest = i.Item3;
                            selected[0] = i;
                        }
                    }
               }
                count++;

            }
            return selected[0];
            Console.WriteLine("MST: (" + String.Join(", ", v) + ")");
			Console.WriteLine("Taken Edges: " + String.Join(", ", ve));
			//Console.WriteLine("Total Cost: " + cost);


        }
    }

}
