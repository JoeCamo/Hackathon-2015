using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionCalls
{
    class functions
    {
        private Dictionary<string, Delegate> dict;
        private List<Delegate> listOfFuncs;
        private string[] udefstrings;
        
        int f1;
        int f2;
        int f3;
        int f4;
        //int i = 0;
        // constructor
        public functions(List<string> udef)
        {
            dict = new Dictionary<string, Delegate>();
            listOfFuncs = new List<Delegate>();

            listOfFuncs.Add(new Action<int>(testFunc1));
            f1 = 0;

            listOfFuncs.Add(new Func<int>(testFunc2));
            f2 = 1;

            listOfFuncs.Add(new Action(testFunc3));
            f3 = 2;

            listOfFuncs.Add(new Func<int, int>(testFunc4));
            f4 = 3;

            udefstrings = udefparse(udef);

            dict[udefstrings[f1]] = listOfFuncs[f1];
            dict[udefstrings[f2]] = listOfFuncs[f2];
            dict[udefstrings[f3]] = listOfFuncs[f3];
            dict[udefstrings[f4]] = listOfFuncs[f4];

            /*dict["ctrl+d"] = new Action<int>(testFunc1);
            dict["ctrl+z"] = new Func<int>(testFunc2);
            dict["ctrl+y"] = new Action(testFunc3);
            dict["ctrl+x"] = new Func<int, int>(testFunc4);*/
            //Action<int d>(testFunc1);

        }

        public void ReturnAndRunFunc(string key)
        {
            Console.WriteLine("these are ran from inside of the functions class");
            dict[udefstrings[f1]].DynamicInvoke(1);
            dict[udefstrings[f2]].DynamicInvoke();
            dict[udefstrings[f3]].DynamicInvoke();
            dict[udefstrings[f4]].DynamicInvoke(1);
            
        }

        private void testFunc1(int input)
        {
            Console.WriteLine("testFunc1 with input no output");

        }
        
        private int testFunc2()
        {
            Console.WriteLine("testFunc2 no input int output");
            return 1;
        }

        private void testFunc3()
        {
            Console.WriteLine("testFunc3 no input no output");
        }

        private int testFunc4(int test)
        {
            Console.WriteLine("testFunc4 with input and return value");
            return 1;
        }

        private string[] udefparse(List<string> udefs)
        {
            // need to change if we add more functions
            string[] toReturn = new string[4];
        
            foreach ( string s in udefs )
            {
                if ( string.Compare(s, 0, "FUNC1", 0, 5) == 0 )
                {
                    toReturn[f1] = s.Substring(s.Length - 6);
                }
                else if ( string.Compare(s, 0, "FUNC2", 0, 5) == 0)
                {
                    toReturn[f2] = s.Substring(s.Length - 6);
                }
                else if ( string.Compare(s, 0, "FUNC3", 0, 5) == 0)
                {
                    toReturn[f3] = s.Substring(s.Length - 6);
                }
                else if ( string.Compare(s, 0, "FUNC4", 0, 5) == 0)
                {
                    toReturn[f4] = s.Substring(s.Length - 6);
                }
                else
                {
                    Console.WriteLine("Function not defined!");
                }
            }

            return toReturn;
        }



    }
}
