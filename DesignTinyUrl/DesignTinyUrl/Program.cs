using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DesignTinyUrl
{

    
    class Program
    {
        static private long Range = 200000;

        public static string Shorturl(string longurl)
        {
            char[] map = new char[]{'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H',
                'I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','1','2','3','4','5','6','7','8','9','0' };

            string path = @"C:\Users\Shwet\source\repos\counter.txt";
            if(!File.Exists(path))
            {

                File.WriteAllText(path, Range.ToString()) ;
               
            }

                long counter = int.Parse(File.ReadAllText(path));
                File.WriteAllText(path, (counter + 1).ToString());
               string shorturl = string.Empty;
               
               

               
              
                    while (counter > 0)
                    {
                        shorturl += map[counter % 62];
                        counter = counter / 62;
                    }

              
            

           
            string mappath = @"C:\Users\Shwet\source\repos\map.txt";
            File.AppendAllText(mappath, "\n" + shorturl + " " + longurl);

          

            return shorturl;
                
                
               
            
        }
        static void Main(string[] args)
        {

            string domain="www.shorturl.com\\";
            string longurl = "https://stackoverflow.com/questionsdnnkkalcjicjdaookckanxaxnakskslsakdoeiddjd";
            string s = Shorturl(longurl);       
            domain = domain + s;
            Console.WriteLine(domain);
        }
    }
}
