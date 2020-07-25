using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiExample.BusinessLayer;

namespace WebApiExample.Controller
{
    public class FarmController : ApiController
    {
        public string get()
        {
            return "Hello World";
        }


        //Endpoint to fetch contests 
        [Route("contests")]
        public IEnumerable<ContestsDetail> getContestsDetails()
        {
            using (TestWallets dbContext = new TestWallets())
            {

                var result = dbContext.ContestsDetails.ToList();
                return result;
            }
        }
        //Endpoint to fetch user details 
        [Route("userContests")]
        public List<UserToContestMapper> getUserContestsDetails([FromUri] int userId)
        {
            using (TestWallets dbContext = new TestWallets())
            {

                var result = dbContext.UserToContestMappers.ToList().FindAll(m=>m.UserId==userId);
                return result;
            }
        }
        //Endpoint to fetch user participated contests 
        [Route("")]
        public IEnumerable<UserDetail> getUserDetails()
            {
                using (TestWallets  dbContext = new TestWallets())
                {

                    var rresult= dbContext.UserDetails.ToList();
                return rresult;
                }
            }

        [Route("AddContest")]
        //save user and contest details 
        public HttpResponseMessage postContestData([FromUri]int userId,[FromUri] int contestId,[FromUri] float discount)
        {
            using (TestWallets dbContext = new TestWallets())
            {

                try {
                    var userResult = dbContext.UserDetails.ToList().Find(m => m.Id == userId);
                    var contestDetail = dbContext.ContestsDetails.ToList().Find(m => m.ContestId == contestId);
                    var contestToUserMapper = dbContext.UserToContestMappers.ToList().Find(m => m.ContestId == contestId && m.UserId == userId);
                    var userWalletAccount = userResult!=null?dbContext.WalletsAccounts.ToList().Find(m => m.WalletId == userResult.WalletId):null;
                    if(contestToUserMapper != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Conflict);
                    }

                    //condition to check whether user and contest exists and if user has already partipcated or not.
                    if (userResult != null && contestDetail != null &&userWalletAccount!=null)
                    {
                        WalletManipulation walletManipulation = new WalletManipulation();
                        int? entryAmount = contestDetail.EntryAmount ?? 0;
                        entryAmount = Convert.ToInt32 (entryAmount-(entryAmount * (discount / 100)));
                        var balance = ((userWalletAccount.BonusBucket> entryAmount / 10)?entryAmount/10:userWalletAccount.BonusBucket) + userWalletAccount.DepositBucket + userWalletAccount.WinningsBucket;
                        WalletsAccount updatedWallet=new WalletsAccount();
                        
                        //condition to check that whether current balance of user is greater than entryAmount or not
                        if (balance >= entryAmount)
                        {
                           updatedWallet = walletManipulation.calculateBalance(userWalletAccount, ref entryAmount);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.PreconditionFailed); 
                        }
                            contestToUserMapper = new UserToContestMapper();
                            contestToUserMapper.BonusAmount = userWalletAccount.BonusBucket-updatedWallet.BonusBucket;
                            contestToUserMapper.DepositAmount = userWalletAccount.DepositBucket - updatedWallet.DepositBucket;
                            contestToUserMapper.WinningsAmount = userWalletAccount.WinningsBucket - updatedWallet.WinningsBucket;
                            contestToUserMapper.DiscountApplied = Convert.ToInt32(discount);
                            contestToUserMapper.UserId = userId;
                            contestToUserMapper.ContestId = contestId;

                            userWalletAccount.BonusBucket = updatedWallet.BonusBucket;
                            userWalletAccount.DepositBucket = updatedWallet.DepositBucket;
                            userWalletAccount.WinningsBucket = updatedWallet.WinningsBucket;
                            userWalletAccount.TotalWalletAmount = userWalletAccount.TotalWalletAmount - contestDetail.EntryAmount;

                            dbContext.UserToContestMappers.Add(contestToUserMapper);
                            dbContext.Entry(userWalletAccount).State =EntityState.Modified;
                            dbContext.SaveChanges();
                            return Request.CreateResponse(HttpStatusCode.OK);

                    }
                    else
                    {

                       return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
            }
            }
           
}

        //endpoint to fetch contest details
    }
}
