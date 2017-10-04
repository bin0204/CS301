using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanEncoding
{
    class Program
    {
        
        //Read text file in char
        public static void readChar(string txt, List<char> chars, List<int> values)
        {
            foreach (char c in txt)
            {
                if (chars.Contains(c))
                {
                    //Find the index for each c, should have list for each char value 
                    int bin = findInt(c, chars);
                    values[bin]++;
                }
                else
                { 
                    //not contains, then it means new
                    chars.Add(c);
                    values.Add(1);
                }
            }
            //To print out the total number of each char
            int index = 0;
            foreach (int c in values)
            {
                Console.WriteLine(chars[index] + " " + c);
                index++;
            }
        }

        public static int findInt(char c, List<char> chars)
        {
            for (int i = 0; i < chars.Count; i++)
            {
                if (chars[i] == c)
                {
                    //return the index
                    return i;
                }
            }
            return 0;
        }
        public class Node
        {
            public Node left;
            public Node right;
            public int value;
            public char c;


            //Make constructor
            public Node(Node left, Node right, int value)
            {
                this.left = left;
                this.right = right;
                this.value = value;
            }

            public Node(char c, int value)
            {
                this.c = c;
                this.value = value;
                this.left = null;
                this.right = null;
            }

        }
        static List<Node> Huffman(List<Node> list)
        {
            //order by in list and then back to list
            list = list.OrderBy(d => d.value).ToList();

            int dd = list.Count;
            for (int d = 0; d < dd - 1; d++)
            {
                Node i = list[0];
                Node j = list[1];
                list.Add(new Node(i, j, i.value + j.value));
                list.RemoveAt(0);
                list.RemoveAt(0);
                list = list.OrderBy(e => e.value).ToList();
            }

            return list;
        }

        static string encode(Node n, List<Node> li, int length)
        {
            List<int> m = new List<int>();
            Node next = n;
            while (true)
            {
                foreach (Node l in li)
                {
                    if (l.left == next)
                    {
                        m.Insert(0, 0);
                        next = l;
                    }
                    else if (l.right == next)
                    {
                        m.Insert(0, 1);
                        next = l;
                    }
                }
                if (next.value == length)
                {
                    break;
                }
            }
            return string.Join("", m);
        }

        static List<string> encodeFile(Dictionary<char, string> s, string v)
        {
            List<string> sl = new List<string>();
            foreach (char c in v)
            {
                string encode;
                s.TryGetValue(c, out encode);
                sl.Add(encode);
            }
            return sl;
        }

      

        static void Main(string[] args)
        {
            //Read the file as string
            string text = System.IO.File.ReadAllText("C:\\Users\\student\\Desktop\\text.txt");
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            //To store the each char in chars
            List<char> chars = new List<char>();
            //To store the value in value
            List<int> values = new List<int>();
            List<Node> nodes = new List<Node>();

            readChar(text, chars,values);
            Console.WriteLine(chars.Count);
            Console.WriteLine(values.Count);
            for (int i = 0; i < chars.Count; i++)
            {
                //parallel 
                nodes.Add(new Node(chars[i],values[i]));
            }


            List<Node> ln = Huffman(nodes);
            List<Node> tree = new List<Node>();
            tree.Add(ln[0]);
            for (int i = 0; i < values.Count*2 - 1; i++)
            {
                if (tree[i].left != null)
                {
                    tree.Add(tree[i].left);
                }
                if (tree[i].right != null)
                {
                    tree.Add(tree[i].right);
                }
            }

            Dictionary<char, string> encodes = new Dictionary<char, string>();
            foreach (char cha in chars)
            {
                foreach (Node o in tree)
                {
                    if (cha == o.c)
                    {
                        //ln[0].value is length of text file
                        String s = encode(o, tree, ln[0].value);
                        encodes.Add(cha, s);
                    }
                }
               
            }

            foreach (KeyValuePair<char, string> key in encodes)
            {
                Console.WriteLine(key.Key + ": " + key.Value);
            }
            
            Console.Read();
        }
    }
}
