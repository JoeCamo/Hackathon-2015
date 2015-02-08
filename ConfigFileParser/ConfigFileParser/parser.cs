using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigFileParser
{
    class parser
    {
        private List<string> lf;
        private List<string> lc;
        private List<string> lu;

        public List<string> get_folders
        {
            get
            {
                return lf;
            }
        }

        public List<string> get_columns
        {
            get
            {
                return lc;
            }
        }

        public List<string> get_user_def
        {
            get
            {
                return lu;
            }
        }

        public parser()
        {
             StreamReader sr;
            string defaultPath = "config.txt";
            string config;
            string f, c, u;
            lf = new List<string>();
            lc = new List<string>();
            lu = new List<string>();
            int start;

            // read from config
            sr = new StreamReader(defaultPath);
            config = sr.ReadToEnd();

            // need to read from : to /n
            int folders = 10;
            int columns = 10;
            int userdef = 10;

            folders += config.IndexOf("folders:");
            columns += config.IndexOf("columns:");
            userdef += config.IndexOf("userdef:");

            start = folders;
            while (folders < config.Length)
            {
                if (config[folders] == '\r' && config[folders + 2] == '\r')
                    break;
                folders++;
            }
            f = mySubStr(config, start, folders);

            start = columns;
            while (columns < config.Length )
            {
                // break while after double space only
                if (config[columns] == '\r' && config[columns + 2] == '\r')
                    break;
                columns++;
            }
            c = mySubStr(config, start, columns);

            start = userdef;
            while ( userdef < config.Length )
            {
                if (config[userdef] == '\r' && config[userdef + 2] == '\r')
                    break;
                userdef++;
            }
            u = mySubStr(config, start, userdef);

            lc = c.Split(',').ToList<string>();
            lf = f.Split(',').ToList<string>();
            lu = u.Split(',').ToList<string>();

            foreach( string item in lc )
            {
                Console.WriteLine(item);
            }

            foreach( string item in lf )
            {
                Console.WriteLine(item);
            }

            foreach(string item in lu )
            {
                Console.WriteLine(item);
            }
        }
        private string mySubStr(string s, int start, int end)
        {
            char[] newString = new char[128];
            string ns;
            int i = 0;

            while ( start < end )
            {
                // skip whitespaces
                if ( s[start] == '\n' )
                {
                    start++;
                }
                // turn \r to ,
                else if (s[start] == '\r')
                {
                    newString[i] = ',';
                    start++;
                    i++;
                }
                // otherwise copy
                else if (s[start] == ';')
                {
                    while ( start < end && s[start] != '\n' )
                    {
                        start++;
                    }
                }
                else
                {
                    newString[i] = s[start];
                    start++;
                    i++;
                }
            }

            ns = new string(newString);
            return ns;
        }
    }
}
