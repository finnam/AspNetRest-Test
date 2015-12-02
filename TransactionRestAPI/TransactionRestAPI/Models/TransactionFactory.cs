using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionRestAPI.Models
{
    public class TransactionFactory
    {
        private static TransactionFactory _factory = null;
        private Dictionary<long, ITransaction> _transactions = null;
        private long _id = 0;
        static TransactionFactory()
        {
            _factory = new TransactionFactory();
        }

        public static TransactionFactory Instance()
        {
            return _factory;
        }
        private TransactionFactory()
        {
            _transactions = new Dictionary<long, ITransaction>();
        }

        public IList<ITransaction> Transactions()
        {
            return _transactions.Select(t => t.Value).ToList().AsReadOnly();
        }

        public ITransaction Get(long id)
        {
            ITransaction t = null;
            _transactions.TryGetValue(id, out t);
            return t;
        }

        public ITransaction Create(Transaction t)
        {
            t.TransactionId = ++_id;
            t.CreatedDate = DateTime.Now;
            t.ModifiedDate = t.CreatedDate;

            _transactions.Add(t.TransactionId, t);
            return t;
        }

        public ITransaction Update(Transaction t)
        {
            t.ModifiedDate = DateTime.Now;
            ITransaction output = null;
            if ( _transactions.TryGetValue(t.TransactionId, out output) )
            {
                Transaction orig = output as Transaction;

                orig.ModifiedDate = DateTime.Now;
                orig.Description = t.Description;
                orig.TransactionAmount = t.TransactionAmount;
                orig.CurrencyCode = t.CurrencyCode;
                orig.Merchant = t.Merchant;
            }
            return output;
        }

        public ITransaction Delete(long id)
        {
            ITransaction tmp = null;
            if (_transactions.TryGetValue(id, out tmp))
            {
                _transactions.Remove(tmp.TransactionId);
            }
            return tmp;
        }
    }
}