using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Data.Entities.General
{
    public class BankAccount
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string AccountNumber { get; set; }
        public BankAccountType BankAccountType { get; set; }
        public string OtherBankAccounttype { get; set; }
        public string BankCode { get; set; }
        public string BranchAddress { get; set; }
    }
    public enum BankAccountType
    {
        Saving = 1,
        Current = 2,
        AutoSave = 3,
        Others = 4
    }
}
