using System;

namespace LongestPrefix
{
    public class Program
    {

        static readonly int ALPHABET_SIZE = 26;
        public class TrieNode
        {

            public TrieNode[] children = new TrieNode[ALPHABET_SIZE];

            // isLeaf is true if the node represents 
            // end of a word 
            public bool isLeaf;

            public TrieNode()
            {
                isLeaf = false;
                for (int i = 0; i < ALPHABET_SIZE; i++)
                    children[i] = null;
            }

        };
        static TrieNode root;
        static int indexs;


        static void insert(String key)
        {
            int length = key.Length;
            int index;
            TrieNode pCrawl = root;

            for (int level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                Console.WriteLine(index+"key index"); 
                if (pCrawl.children[index] == null)
                    pCrawl.children[index] = new TrieNode();

                pCrawl = pCrawl.children[index];
            }
            // mark last node as leaf 
            pCrawl.isLeaf = true;
        }
        static int countChildren(TrieNode node)
        {
            int count = 0;
            for (int i = 0; i < ALPHABET_SIZE; i++)
            {
                if (node.children[i] != null)
                {
                    count++;
                    indexs = i;
                    //Console.WriteLine(indexs + "In count" + count);
                }
            }
            return (count);
        }

        static String walkTrie()
        {
            TrieNode pCrawl = root;
            indexs = 0;
            String prefix = "";

            while (countChildren(pCrawl) == 1 &&
                    pCrawl.isLeaf == false)
            {
                pCrawl = pCrawl.children[indexs];
                prefix += (char)('a' + indexs);
                //Console.WriteLine(indexs+"In walktire");
            }
            return prefix;
        }



        static void Main(string[] args)
        {

            string[] s = { "geeks"};
            root = new TrieNode();
            for (int i=0;i<s.Length;i++)
            {
                insert(s[i]);
            }

            string prefix = walkTrie();
            Console.WriteLine(prefix);
        }
    }
}
 

