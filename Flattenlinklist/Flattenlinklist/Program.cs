using System;

namespace Flattenlinklist
{
    class Program
    {
        static void Main(string[] args)
        {

            LinkedList list = new LinkedList();
            list.head = null;
            int[]  arr = { 3, 44, 55, 66 };
            int[]  arr2 = { 20, 30, 40 };
            int[] arr3 = { 5, 6, 7};

            list.createVerticalList(arr);
            list.createVerticalList(arr2);
            list.createVerticalList(arr3);
            list.print_list();
            list.head=list.flatten(list.head);
            node temp = list.head;
            while (temp != null)
            {
                Console.WriteLine("MM" + temp.data);
                temp = temp.down;
            }




        }
    }
}
