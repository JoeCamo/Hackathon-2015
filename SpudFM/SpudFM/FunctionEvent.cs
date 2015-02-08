using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpudFM
{
    class FunctionEvent : EventArgs
    {
        private readonly string text;

        public FunctionEvent(string text)
        {
            this.text = text;
        }

        public string Text
        {
            get
            {
                return this.text;
            }
        }
    }
}
