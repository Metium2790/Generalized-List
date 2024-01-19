using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generalized_List
{
    class Program
    {
        static void Main(string[] args)
        {
            //simple command access
            Console.WriteLine("1-Make a list(20 max)");
            Console.WriteLine("2-Add to list");
            Console.WriteLine("3-Find depth of the list");
            Console.WriteLine("4-Print the list");
            Console.WriteLine("5-Find all amounts of the nodes");
            Console.WriteLine("6-Find a data and delete them from the list");
            Console.WriteLine("7-Make a double list and add all the list item to it");
            Console.WriteLine("8-Compare 2 list to each other");
            Console.WriteLine("0-EXIT");

            GList[] lists = new GList[20]; //array to save lists
            looplist[] looplists = new looplist[20];
            int listnum = -1;
            int listnum2 = -1;
            int list = 0; //amount of active lists
            int looplist = 0;

            while (true)
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.Write("LISTS: ");
                for (int i = 0; i < list; i++)
                {
                    Console.Write((i+1)+",");
                }
                Console.WriteLine("");
                Console.Write("LOOP LISTS: ");
                for (int i = 0; i < looplist; i++)
                {
                    Console.Write((i + 1) + ",");
                }

                Console.WriteLine("");
                string CMD = Console.ReadLine();

                switch (CMD)
                {
                    case "1":
                        lists[list] = new GList();
                        list++;
                        Console.WriteLine("List maded!!");
                        break;
                    case "2":
                        Console.WriteLine("which list you want to add choose?");
                        listnum = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Your Data inside the new node: ");
                        Node newnode = new Node(Console.ReadLine());
                        lists[listnum-1].Add(newnode);
                        Console.WriteLine("ADDED");
                        break;
                    case "3":
                        Console.WriteLine("which list you want to find choose?");
                        listnum = Int32.Parse(Console.ReadLine());
                        lists[listnum-1].Depth();
                        break;
                    case "4":
                        Console.WriteLine("which list you want to choose?");
                        listnum = Int32.Parse(Console.ReadLine());
                        lists[listnum-1].Display();
                        Console.WriteLine("");
                        break;
                    case "5":
                        Console.WriteLine("which list you want to choose?");
                        listnum = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Amount of nodes: "+lists[listnum-1].Allnodes());
                        break;
                    case "6":
                        Console.WriteLine("which list you want to choose?");
                        listnum = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("What's the data you want to delete?");
                        string deldata = Console.ReadLine();
                        lists[listnum-1].delete(deldata);
                        break;
                    case "7":
                        Console.WriteLine("which list you want to choose?");
                        listnum = Int32.Parse(Console.ReadLine());
                        looplists[looplist] = lists[listnum - 1].turntoloop();
                        lists[listnum - 1] = lists[listnum];
                        looplist++;
                        list--;
                        looplists[looplist-1].Display();
                        Console.WriteLine("");
                        break;
                    case "8":
                        Console.WriteLine("which 1st list you want to choose?");
                        listnum = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("which 2nd list you want to choose?");
                        listnum2 = Int32.Parse(Console.ReadLine());
                        Console.Write("Are they equal ? " + lists[listnum-1].Comparison(lists[listnum2-1]));
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please use the right command");
                        break;
                }
            }



        }
    }
}//Coded by Mohammad Mahdi Mohammadi (AKA Metium)
