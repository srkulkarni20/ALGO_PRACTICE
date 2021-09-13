//Linked List operationa
using System;

namespace Assignment_7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.create_node(5);
            list.create_node(55);
            list.head =list.reverse_kthnode(list.head, 3);
            Console.WriteLine("print");
            list.print_list();

            LinkedList list2 = new LinkedList();
            
            list2.create_node(4);
            list2.create_node(55);
            list2.create_node(70);
            list2.create_node(43);
            list2.create_node(58);
            list2.create_node(73);
            list2.print_list();
            list2.rotate_counter(8);
             

            list2.print_list();

            node m_ptr= LinkedList.sort_merge(list.head, list2.head);
            Console.WriteLine(m_ptr.data);
            LinkedList.printstatic_list(m_ptr);
            list2.print_list();

            LinkedList list3 = new LinkedList();
            LinkedList list4 = new LinkedList();

            list3.create_node(3);
            list3.create_node(4);

            list4.create_node(7);
            list4.create_node(8);
            list4.create_node(6);

            list4.create_node(9);
            list4.create_node(7);



            list4.print_list();
            list4.swap_pair(list4.head);
           
            //LinkedList.print_sum(list3.head, list4.head);

            //list.reverse();
            list4.head=list4.reverse_kthnode(list4.head, 2);
            Console.WriteLine("reverse List");
            list4.print_list();
            node n = list4.find_middle(list4.head);
            Console.WriteLine(n.data + "middle");
            bool val =list4.isPaliandrome(list4.head);
            Console.WriteLine(val);
            // list.rotate_counter(5);
            // list.print_list();
            // list.find_nthnode(5);
        }
    }
}
