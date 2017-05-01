using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
    public interface IReceiptService
    {
        Receipt GetReceipt(int id);
        void CreateReceipt(Receipt receipt);
        void UpdateReceipt(Receipt receipt);
        void SaveReceipt();
        Task<int> SaveReceipttAsync();
    }
}
