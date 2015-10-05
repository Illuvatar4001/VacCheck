using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacCheckWPF
{
    class SteamUri : Uri
    {
        public string displaystring {get ;set    ;}

        public SteamUri(string link, string display) :base(link)
        {
            displaystring = display;
        }
        public override string ToString()
        {
            return displaystring;
        }
    }
}
