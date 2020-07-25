using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiExample.Model
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string username { get; set; }
        public Wallet wallet { get; set; }

        public List<ContestDetails> participatedContests { get; set; }

    }

    public class Wallet
    {
        public int bonusWalletAmount { get; set; }
        public int depositWalletAmount { get; set; }
        public int winningsWalletAmount { get; set; }
    }

    public class ContestDetails
    { 
       public int contestId { get; set; }
        public string contestName { get; set; }
       public int depositAmount { get; set; }
    }
}