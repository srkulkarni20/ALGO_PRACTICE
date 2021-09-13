using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Flattenlinklist
{

    public class node
    {
        public int data;
        public node right;
        public node down;
        public node()
        {
            right = null;
            down = null;
        }
    
    }
    public class LinkedList
    {
        public node head;


        public void  createVerticalList(int[] arr)
        {
            node first_node = new node();
            first_node.data = arr[0];
            if (this.head == null)
            {              
                 this.head = first_node;
            }
            else
            {
                node t = head;
                while(t.right != null)
                {
                    t = t.right;

                }
               
                t.right = first_node;
            }

            node temp = first_node; 
            for(int j=1;j<arr.Length;j++)
            {
                node d = new node();
                temp.down = d;
                d.data = arr[j];
                temp = d;
                
            }

            
        }


        public void print_list()
        {
            node lin_nodes = head;
            node down_nodes;

            while (lin_nodes != null)
            {
                down_nodes = lin_nodes;
                while (down_nodes != null)
                {
                    Console.WriteLine(down_nodes.data + "lll");
                    down_nodes = down_nodes.down;
                }
                lin_nodes = lin_nodes.right;
            }

        }

        public node flatten(node head)
        {
            if(head.right==null)
            {
                return head;
            }
           
            node res= Sortedmerge(head, flatten(head.right));
            return res;
           
            
        }


        public node Sortedmerge(node h1,node h2)
        {

           
            Console.WriteLine("insorted merge");
            if(h1==null)
            {            
                return h2;
            }
            if(h2==null)
            {             
               return h1;
            }
            node res;
            if (h1.data < h2.data)
            {
                res = h1;
                res.down = Sortedmerge(h1.down, h2);               
            }
            else
            {
                res = h2;
                res.down = Sortedmerge(h1, h2.down);
               
            }
            res.right = null;
            return res;
            
        }

    };

}
