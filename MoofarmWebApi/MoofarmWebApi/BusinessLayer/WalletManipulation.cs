using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExample.Model;

namespace WebApiExample.BusinessLayer
{
    public class WalletManipulation
    {
        //method for business logic.
        public WalletsAccount calculateBalance( WalletsAccount walletBucket,ref int? entryFees)
        {
            var bonusAmount = walletBucket.BonusBucket;
            var depositAmount = walletBucket.DepositBucket;
            var winningsAmount = walletBucket.WinningsBucket;
            WalletsAccount updatedWallet = new WalletsAccount();
            updatedWallet.BonusBucket = entryFees / 10 < bonusAmount ? bonusAmount - (entryFees / 10) : 0;
            entryFees = entryFees-(bonusAmount - updatedWallet.BonusBucket);
            updatedWallet.DepositBucket = entryFees>0?depositAmount>entryFees?depositAmount -entryFees:0:depositAmount;
            entryFees = entryFees-(depositAmount - updatedWallet.DepositBucket);
            updatedWallet.WinningsBucket= entryFees > 0 ? winningsAmount > entryFees ? winningsAmount - entryFees :0 :winningsAmount;
            entryFees = entryFees - (winningsAmount - updatedWallet.WinningsBucket);
            return updatedWallet;

        }
    }
}