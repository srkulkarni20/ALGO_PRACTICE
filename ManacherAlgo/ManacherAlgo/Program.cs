using System;
using System.ComponentModel;
using System.Reflection.Emit;

namespace ManacherAlgo
{
    class Program
    {

        static public string construct_string(string s)
        {
            string newstr = "#";

            for(int i=0;i<s.Length;i++)
            {
                newstr = newstr+s[i]+"#";

            }
            return newstr;
        }
        static public void find(string s)
        {

            int[] Len = new int[s.Length];
            int center = 0, Right_boundary = 0;
            int maxindex = 0;
            Len[0] = 0;
            for(int i=1;i<s.Length;i++)
            {
                
                if(i<Right_boundary)
                {
                    int mirr = 2 * center - i;
                    Len[i] = Math.Min(Right_boundary - i, Len[mirr]);  //uodate to whatever possiblr and continue expamsion
                }

                Len[i] = expand_paliandrome(s, i, Len[i]);
               
                if (i + Len[i] > Right_boundary)
                {
                    center = i;
                    Right_boundary = i + Len[i];
                }
               
                if(Len[maxindex]<Len[i])
                {
                    maxindex = i;
                }

            }

         
            string pal = string.Empty;
            for(int i = maxindex-Len[maxindex];i<=maxindex+Len[maxindex];i++)
            {
                if(s[i]!='#')
                {
                    pal = pal + s[i];
                }
            }

            Console.WriteLine(pal);
            
        }

        static public int expand_paliandrome(string s, int index, int len)
        {
            int start, end;
            end = index + len + 1;
            start = index-len-1;   //to skip comparisions
            while(start>=0 && end<s.Length)
            {
                if (s[start] == s[end])
                {
                    len++;
                }
                else
                {
                    break;
                }
                start--;
                end++;
            }
            return len;
        }
        static void Main(string[] args)
        {

            string s = "aaaabbaa";
            string newstr = construct_string(s);

            find(newstr);
        }
    }
}
