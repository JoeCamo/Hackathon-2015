using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FunctionCalls
{
    class SearchStrings
    {
        List<string> listToSearch;
        Regex r;
        
        public SearchStrings(List<string> passedStrings)
        {
            listToSearch = passedStrings;
        }

        public List<string> DisplayStringsFromInput(string input)
        {
            List<string> listToReturn = new List<string>();
            string regexString = "*" + input + "*";
            r = new Regex(regexString);

            foreach( string s in listToSearch )
            {
                if (r.IsMatch(s))
                {
                    listToReturn.Add(s);
                }
            }


            return listToReturn;
        }
    }
}
