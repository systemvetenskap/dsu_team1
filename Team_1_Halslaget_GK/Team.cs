using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team_1_Halslaget_GK
{
    public class Team
    {
        public string id { get; set; }
        public string namn { get; set; }

        public List<medlem> Listofmedlem { get; set; }
    }

    
}