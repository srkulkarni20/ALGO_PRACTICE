using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Assignment_7_1
{

    public class node
    {
        public int data;
        public node next;
    };
    public class LinkedList
    {

        public node head;




        public void create_node(int val)
        {

            node n = new node();
            n.data = val;
            node temp;
            if (this.head == null)
            {
                head = n;
                n.next = null;
            }
            else
            {
                temp = head;
                while(temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = n;
                n.next = null;
                
            }
            n.next = null;


        }

        public void print_list()
        {
            node temp = head;
            while(temp!=null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }

        public void reverse()
        {

            node prev, curr;
            prev = null;
           
           
            while (head!= null)
            {
                curr = head;
                head = head.next;
                curr.next = prev;
                prev = curr;                           
            }

            head = prev;          

        }

        /*Given a linked list, write a function to reverse every k nodes (where k is an input to the function).
         * If a linked list is given as 1->2->3->4->5->6->7->8->NULL and k = 3 then output will be 3->2->1->6->5->4->8->7->NULL.*/
        public node reverse_kthnode(node head,int k)
        {
            int size = k;
            node prev, curr, next=head;
            prev = null;
            curr = head;        

            while (next != null&& size>0)
                {
                   curr = next;
                   next = curr.next;
                   curr.next = prev;
                   prev = curr;
                   size--;
                }

            if (next!= null)
            {
                Console.WriteLine(curr.data+"inside reverss");
                head.next = reverse_kthnode(next, k);
            }

            return prev;

        }

        public node find_middle(node head)
        {
            if(head.next==null||head==null)
            {
                return head;
            }
            node slow, fast;
            slow =head;
            fast = head;
            while(fast!= null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

            }
            print_list();
            Console.WriteLine($"In findmiddle{head.data},{slow.data}");

            return slow;
        }

        /*Given a singly linked list, rotate the linked list counter-clockwise by k nodes. 
         * Where k is a given positive integer smaller than or equal to length of the linked list. 
         * For example, if the given linked list is 10->20->30->40->50->60 
         * and k is 4, the list should be modified to 50->60->10->20->30->40.*/

        public void rotate_counter(int k)
        {
            node ptr_k, ptr_end;
            int count = 0;
            ptr_end = ptr_k = head;
            while(ptr_end.next != null)
            {
                if (count < k- 1)
                {
                    ptr_k = ptr_k.next;
                    count++;                 
                }
                ptr_end = ptr_end.next;
            }

            if (count < k - 1)
            {
                Console.WriteLine("Invalid Input : k is bigger then the length of linked list");
            }
            else
            {

                ptr_end.next = head;
                head = ptr_k.next;
                ptr_k.next = null;
            }


        }

        //Given a linked list, the task is to find the n'th node from the end. 
        public void find_nthnode(int n)
        {
            node slow, fast;
            slow = fast = head;
            int i = 1;
            if(n==0 || n<0)
            {
                Console.WriteLine("Invalid Input");
                return;
            }
            while(i<n)
            {
                fast = fast.next;
                if (fast == null)
                {
                    Console.WriteLine($"Invalid Input ..{n} should be less than length {i} ");
                    return;
                }

                 i++;
            }
           
            while(fast.next != null)
            {
                slow = slow.next;
                fast = fast.next;
            }
            Console.WriteLine(slow.data);
            return;
        }

        //Given two linked lists sorted in ascending order. Merge them in-place and return head of the merged list.   
        //For example, if first list is 10->20->30 and second list is 15->17, then the result list should be 10->15->17->20->30.

        public static node sort_merge(node head_first,node head_second)
        {
            node first_list = head_first, sec_list = head_second, temp; ;

            if (head_first == null)
                return head_second;
            if (head_second == null)
                return head_first;
            if (head_second.data < head_first.data)
            {
                first_list = head_second;
                sec_list = head_first;              
            }
            node prev = first_list;
            head_first = first_list;
            while(first_list!= null && sec_list != null)
            {
                if(first_list.data<sec_list.data)
                {
                    prev= first_list;
                    first_list = first_list.next;
                    
                }
                else
                {
                    temp = prev.next;
                    prev.next = sec_list;
                    prev = sec_list;
                    sec_list = sec_list.next;
                    prev.next = temp;
                    
                }

            }

            if(sec_list != null)
            {
                prev.next = sec_list;
               

            }
            

            return head_first;


        }

        //Given two numbers represented by two lists, write a function that returns sum list. The sum list is list representation of addition of two input numbers.
       // Suppose you have two linked list 5->4 ( 4 5 )and 5->4->3( 3 4 5) you have to return  a resultant linked list 0->9->3 (3 9 0).

        public static void print_sum(node head_first,node head_second)
        {
            node first_list = head_first;
            node sec_list = head_second;
            int carry = 0, curr_sum;
            
            LinkedList res = new LinkedList();
            while(first_list != null || sec_list != null)
            {
                          
                    curr_sum = (first_list !=null?first_list.data:0) + (sec_list!= null?sec_list.data:0) + carry;                   
                    carry = curr_sum >= 10 ? 1 : 0;
                    curr_sum %= 10;
                    res.create_node(curr_sum);
                    if(first_list != null)
                     {
                      first_list = first_list.next;
                     }
                    if (sec_list != null)
                    {
                      sec_list = sec_list.next;
                    }
            }

            res.print_list();



        }


        public static void printstatic_list(node h)
        {
            
            while (h != null)
            {
                Console.Write(h.data + " ");
                h = h.next;
            }
            Console.WriteLine();
        }


        //Given a singly linked list, write a function to swap elements pairwise.For example, if the linked list is 1->2->3->4->5 
           // then the function should change it to 2->1->4->3->5, and if the linked list is 1->2->3->4->5->6 then the function should change it to 2->1->4->3->6->5.

        public node swap_pair(node h)
        {
            if(h==null||h.next==null)
            {
                return h;
            }
            node curr = h;
            while (curr!= null && curr.next != null)
            {
                
                    int d = curr.data;
                    curr.data = curr.next.data;
                    curr.next.data = d;
                    curr = curr.next.next;

            }
            printstatic_list(h);
            return h;
        }

        //Given a linked list, check if the the linked list has a loop. Linked list can contain self loop.

        public bool loop(node h)
        {
            node slow_ptr = h, fast_ptr = h;
            if(h==null)
            {
                return false;
            }
            if(slow_ptr.next==fast_ptr)
            {
                return true;  //single node with loop
            }

            while(slow_ptr != null && fast_ptr != null && fast_ptr.next != null)
            {
                slow_ptr = slow_ptr.next;
                fast_ptr = fast_ptr.next.next;
                if (slow_ptr == fast_ptr)
                {
                    return true;
                }

            }
            return false;
        }

        //Given a singly linked list of integers, Your task is to complete the function isPalindrome that returns true if the given list is palindrome, else returns false.
          public bool isPaliandrome(node h)
           {
            node slow_ptr = h, fast_ptr = h;
            node prev_slow_ptr = head;
            node midnode = null;
            bool res=false;
            if(h == null && h.next == null)
            {
                return true;
            }

            while(fast_ptr != null && fast_ptr.next != null)
            {
                prev_slow_ptr = slow_ptr;
                slow_ptr = slow_ptr.next;
                fast_ptr = fast_ptr.next.next;
               
            }
            if (fast_ptr != null)
            {
                midnode = slow_ptr;  //  store midnode  fastptr will not become null if its odd elements
                slow_ptr = slow_ptr.next;
            }

            node second_half = slow_ptr;
            prev_slow_ptr.next = null;
            printstatic_list(h) ;

            Console.WriteLine( slow_ptr.data+"kkk"+second_half.data);

            second_half= reverse_half(second_half);
            printstatic_list(second_half);

            node first = h, sec = second_half;
            printstatic_list(second_half);
            while (first !=null && sec != null)
            {
                if(first.data == sec.data)
                {
                    Console.WriteLine("ll");
                    first = first.next;
                    sec= sec.next;
                  
                }
                else
                {
                    Console.WriteLine("kk");
                    res = false;
                    break;
                  
                   
                }

                
            }

            if(first==null && sec==null)
            {
                Console.WriteLine("ll");
                res=true;
            }
            second_half = reverse_half(second_half);
            if (midnode != null)
            {
                prev_slow_ptr.next = midnode;
                midnode.next = second_half;
                
            }
            else
            {
                prev_slow_ptr.next = second_half;
            }
            printstatic_list(h);
            return res;




        }


        public node reverse_half(node start)
        {
            node prev, curr = start, next = start;
            prev = null;


            while (next != null)
            {
                curr = next;
                next = curr.next;
                curr.next = prev;
                prev = curr;
            }

            return prev;
        }
      
    };
}
