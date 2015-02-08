using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpudFM
{
    class functions
    {
        //private Dictionary<string, Delegate> dict;
        private List<string> lof;
        private Dictionary<string, string> dict;
        //private List<Delegate> listOfFuncs;
        public event EventHandler fHandlers = delegate { };

        // constructor
        public functions(List<string> udef)
        {
            dict = new Dictionary<string, string>();
            udefparse(udef);
        }

        public void ReturnAndRunFunc(string key)
        {
            fHandlers(this, new FunctionEvent(dict[key]));
        }

        private void udefparse(List<string> udefs)
        {
            // need to change if we add more functions
            //string[] toReturn = new string[8];
        
            foreach ( string s in udefs )
            {
                if ( string.Compare(s, 0, "NEWTAB", 0, 6) == 0 )
                {
                    dict[s.Substring(s.Length - 7)] = "NEWTAB";
                }
                else if ( string.Compare(s, 0, "CLOSETAB", 0, 8) == 0)
                {
                    dict[s.Substring(s.Length - 9)] = "CLOSETAB";
                }
                else if ( string.Compare(s, 0, "CYCLETAB", 0, 8) == 0)
                {
                    dict[s.Substring(s.Length - 9)] = "CYCLETAB";
                }
                else if ( string.Compare(s, 0, "CYCTLETABBW", 0, 10) == 0)
                {
                    dict[s.Substring(s.Length - 11)] = "CYCLETABBW";
                }
                else if ( string.Compare(s, 0, "UPFOLDER", 0, 8) == 0)
                {
                    dict[s.Substring(s.Length - 9)] = "UPFOLDER";
                }
                else if ( string.Compare(s, 0, "COPYSTRING", 0, 10) == 0)
                {
                    dict[s.Substring(s.Length - 11)] = "COPYSTRING";
                }
                else if ( string.Compare(s, 0, "COPYFILE", 0, 8) == 0)
                {
                    dict[s.Substring(s.Length - 9)] = "COPYFILE";
                }
                else if ( string.Compare(s, 0, "PASTEFILE", 0, 9) == 0)
                {
                    dict[s.Substring(s.Length - 10)] = "PASTEFILE";
                }
                else
                {
                    MessageBox.Show("invalid hotkey change added");
                }
            }
        }

        protected virtual void OnFunctionRun(EventArgs e)
        {
            EventHandler handler = fHandlers;

            handler(this, e);
        }
    }
}
/* dict[udefstrings[f1]].DynamicInvoke(1);
 dict[udefstrings[f2]].DynamicInvoke();
 dict[udefstrings[f3]].DynamicInvoke();
 dict[udefstrings[f4]].DynamicInvoke(1); */

//dict[udefstrings[f1]] = listOfFuncs[f1];

/*dict["ctrl+d"] = new Action<int>(testFunc1);
dict["ctrl+z"] = new Func<int>(testFunc2);
dict["ctrl+y"] = new Action(testFunc3);
dict["ctrl+x"] = new Func<int, int>(testFunc4);*/
//Action<int d>(testFunc1);

/*dict = new Dictionary<string, Delegate>();
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
dict[udefstrings[f4]] = listOfFuncs[f4];*/

/*private void testFunc1(int input)
{
    OnFunctionRun(new EventArgs());
            
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
}*/