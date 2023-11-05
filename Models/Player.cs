using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Models
{
    public class Player
    {
        // Write your Player class here...  
        public int Id{get;set;}
        public string Name{get;set;}
        public int Age{get;set;}
        public string Category{get;set;}
        public decimal BiddingPrice{get;set;}

        public virtual Team Team{get;set;}      
    }
}