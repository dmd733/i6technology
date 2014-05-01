using System.Linq;
using Framework.Accounting.Models;

namespace Framework.Accounting.Interfaces
{
    public interface IGeneralLedgerService
    {
        IQueryable<Account> GetAllGlAccounts();
    }
}
