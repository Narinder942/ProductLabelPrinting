using ProductLabelPrinting.Models.Common;

namespace ProductLabelPrinting.Repository.Abstract
{
    public interface IAccountRepository
    {
        ResponseReturn CheckUser(string employeeCode, string password);
    }
}