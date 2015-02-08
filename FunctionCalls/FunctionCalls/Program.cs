using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FunctionCalls
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> l = new List<string>();
            List<string> toPrint;// = new List<string>();

            l.Add("asdfasdfasdf");
            l.Add("tester");
            l.Add("C:\testagainwith\a\folder");

            parser p = new parser();
            functions f = new functions(p.get_user_def);
            SearchStrings s = new SearchStrings(l);

            f.ReturnAndRunFunc("lol");

            StringBuilder str = new StringBuilder();
            char c = '\0';

            while ( c != '\n' )
            {
                str.Append(Console.Read());
                toPrint = s.DisplayStringsFromInput(str.ToString());
                foreach(string asdf in toPrint)
                {
                    Console.WriteLine(asdf);
                }
            }
            Console.ReadLine();
        }
    }
}
