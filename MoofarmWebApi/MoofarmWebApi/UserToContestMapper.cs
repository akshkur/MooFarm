//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiExample
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserToContestMapper
    {
        public int TransactionId { get; set; }
        public int ContestId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> DiscountApplied { get; set; }
        public Nullable<int> DepositAmount { get; set; }
        public Nullable<int> BonusAmount { get; set; }
        public Nullable<int> WinningsAmount { get; set; }
    
        public virtual UserToContestMapper UserToContestMapper1 { get; set; }
        public virtual UserToContestMapper UserToContestMapper2 { get; set; }
    }
}
