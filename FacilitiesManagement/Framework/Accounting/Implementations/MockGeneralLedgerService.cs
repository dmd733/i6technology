using System.Collections.Generic;
using System.Linq;
using Framework.Accounting.Interfaces;
using Framework.Accounting.Models;

namespace Framework.Accounting.Implementations
{
    public class MockGeneralLedgerService : IGeneralLedgerService
    {

        public IQueryable<Account> GetAllGlAccounts()
        {
            var list = new List<Account>
            {
                new Account {Number = "8800420", Name = "Fire Protection"},
                new Account {Number = "8800422", Name = "Purchased Parts"},
                new Account {Number = "8800424", Name = "Outside Maintenance"},
                new Account {Number = "8800426", Name = "Maintenance: Lands & Buildings"},
                new Account {Number = "8800430", Name = "Janitorial Services"},
                new Account {Number = "8800434", Name = "Supplies: Office"},
                new Account {Number = "8800436", Name = "Publications & Subscriptions"},
                new Account {Number = "8800438", Name = "Supplies: Production"},
                new Account {Number = "8800440", Name = "Supplies: Maintenance"},
                new Account {Number = "8800442", Name = "Supplies: Computer"},
                new Account {Number = "8800444", Name = "IT Solutions: Software"},
                new Account {Number = "8800446", Name = "Vehicle Operating Expense"},
                new Account {Number = "8800448", Name = "Advertising"},
                new Account {Number = "8800452", Name = "Furniture"},
                new Account {Number = "8800454", Name = "Rent: Systems Equipment"},
                new Account {Number = "8800456", Name = "Rent: Machinery & Equipment"},
                new Account {Number = "8800458", Name = "Electricity"},
                new Account {Number = "8800460", Name = "Gas and Fuel"},
                new Account {Number = "8800462", Name = "Water and Waste Water"},
                new Account {Number = "8800464", Name = "Asbestos Abatement Act"}

            };
            return list.AsQueryable();
        }
    }
}