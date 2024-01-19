using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generalized_List
{
    public class Node //node class
    {
        public string data;
        public bool flag;
        public Node link;
        public Node blink; //usage of the double way loop linked list
        public GList dlink;

        public Node(string d)
        {
            data = d;
            flag = false;
            link = null;
            blink = null;
            dlink = null;
        }

    }

    public class looplist //double way loop linked list
    {
        private Node first;

        public void Add(Node d = null, looplist ll = null)
        {
            if (d != null)
            {
                if (first == null)
                {
                    first = d;
                    while(d.link!=null)
                    {
                        d = d.link;
                    }
                    d.link = first;
                    first.blink = d;
                }
                else
                {
                    Node p = first;
                    while (p.link != first)
                    {
                        p = p.link;
                    }
                    p.link = d;
                    d.blink = p;
                    d.link = first;
                }
            }
            else if (ll != null)
            {
                if (first == null)
                {
                    first = ll.first;
                }
                else
                {
                    Node q = ll.first;
                    Node p = first;
                    while (p.link != first)
                    {
                        p = p.link;
                    }
                    while (q.link != first)
                    {
                        q = q.link;
                    }
                    q.link = first;
                    first.blink = q;

                    p.link = ll.first;
                    ll.first.blink = p;
                }
            }
        }
        public void Display() //prints out the list
        {
            Node p = first;
            Console.Write("<"+p.data+",");
            p = p.link;
            while (p.link != first)
            {
                Console.Write(p.data+",");
                p = p.link;
            }
            Console.Write(p.data+">");
        }
    }

    public class GList //generalized list
    {
        private Node first;

        public void Add(Node d=null,GList l=null) //adds to the list
        {   if(d!=null)
            {
                if (first != null)
                {
                    Node p = first;
                    while (p.link != null)
                    {
                        p = p.link;
                    }
                    p.link = d;
                }
                else
                {
                    first = d;
                }
            }
            else if (l != null)
            {
                if (first != null)
                {
                    Node p = first;
                    while (p.link != null)
                    {
                        p = p.link;
                    }
                    p.link = l.first;
                }
                else
                {
                    first = l.first;
                }
            }
        }


        public void Add_dlink(Node p, Node d=null,GList l=null) //adds to the down list of the chosen node
        {
            if (d != null)
            {
                if (p.flag == false)
                {
                    p.flag = true;
                    GList newlink = new GList();

                    newlink.Add(d);

                    p.dlink = newlink;
                }
                else
                {
                    p.dlink.Add(d);
                }
            }
            else if (l != null)
            {
                if (p.flag == false)
                {
                    p.flag = true;

                    p.dlink = l;
                }
                else
                {
                    p.dlink.Add(l: l);
                }
            }
        }

        public void Display() //prints out the list
        {
            Node p = first;
            Console.Write("<");
            if (p != null)
            {
                while (p != null)
                {
                    Console.Write(p.data);
                    if (p.flag)
                    {
                        p.dlink.Display();
                    }
                    if(p.link != null)
                        Console.Write(",");
                    p = p.link;
                }
                Console.Write(">");
            }
        }

        public int Depth() //finds the depth of the list and returns it
        {
            int dep = 0;
            int n = 0;
            Node p = first;

            while(p!=null)
            {
                if (p.flag == true)
                {
                    n = p.dlink.Depth();
                    if (n > dep)
                    {
                        dep = n;
                    }
                }
                p = p.link;
            }
            return dep + 1;
        }

        public int Allnodes() //finds the total amount of the nodes and returns it
        {
            int n = 0;
            Node p = first;

            while (p != null)
            {
                if (p.flag == true)
                {
                    n += p.dlink.Allnodes();
                }
                p = p.link;
            }
            return n;
        }

        public void delete(string x) //delete out a data from the list
        {
            Node q = null;
            Node p = first;
            while(p!=null)
            {
                if (p.flag == true)
                {
                    p.dlink.delete(x);
                }
                if (p.data == x)
                {
                    if (q != null)
                    {
                        q.link = p.link;
                        p.link = null;
                        p = q.link;
                    }
                    else
                    {
                        first = p.link;
                        p.link = null;
                        p = first;
                    }
                }
                else
                {
                    q = p;
                    p = p.link;
                }
            }
        }

        public looplist turntoloop() //turns a generalized list to a looplist
        {
            looplist list = new looplist();
            Node g = first;
            
            while (g != null && g.link!=first)
            {
                if (g.flag == true)
                {
                    list.Add(ll:g.dlink.turntoloop());
                }
                Node p = new Node("");
                p = g;
                list.Add(p);
                g = g.link;
            }
            return list;
        }


        public bool Comparison(GList L) //compares 2 lists with each other
        {
            bool result = false;
            Node p = first;
            Node q = L.first;

            while (q != null && p != null)
            {
                if (q.flag == true && p.flag == true)
                {
                    if (p.dlink.Comparison(q.dlink) == false)
                    {
                        result = false;
                        break;
                    }
                    else
                    {
                        result = p.dlink.Comparison(q.dlink);
                        if (p.data == q.data)
                            result = true;
                        q = q.link;
                        p = p.link;
                    }
                }
                else if (q.flag == false && p.flag == false)
                {
                    if (q.data != p.data)
                    {
                        result = false;
                        break;
                    }
                    else
                    {
                        result = true;
                    }
                    q = q.link;
                    p = p.link;

                }
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

    }

}
