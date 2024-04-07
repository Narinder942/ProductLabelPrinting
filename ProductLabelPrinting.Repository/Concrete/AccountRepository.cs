using ProductLabelPrinting.Models.Common;
using ProductLabelPrinting.Repository.Abstract;
using ProductLabelPrinting.Services.Interactions;

namespace ProductLabelPrinting.Repository.Concrete
{
    public class AccountRepository : IAccountRepository
    {
        public ResponseReturn CheckUser(string employeeCode, string password)
        {
            using (AccountService accountService = new AccountService())
            {
                return accountService.CheckUser(employeeCode, password);
            }


        }
    }
}