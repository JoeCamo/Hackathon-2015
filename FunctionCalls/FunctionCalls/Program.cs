using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalls
{
    class Program
    {
        static void Main(string[] args)
        {
            parser p = new parser();
            functions f = new functions(p.get_user_def);

            f.ReturnAndRunFunc("lol");
            Console.ReadLine();
        }
    }
}
