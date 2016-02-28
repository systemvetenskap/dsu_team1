using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team_1_Halslaget_GK
{
    public class medlem
    {
        public int ID { get; set;}
        public string fornamn { get; set; }
        public string efternamn { get; set; }
        public double handikapp { get; set; }      
    
        public override string ToString()
        {
            return ID + " " + fornamn + " " + efternamn + " " + handikapp;
        }
    }
}