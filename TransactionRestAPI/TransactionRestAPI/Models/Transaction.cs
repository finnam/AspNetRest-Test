using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionRestAPI.Models
{
    public interface ITransaction
    {
        long TransactionId { get;  }
        DateTime TransactionDate { get;  }
        string Description { get;  }
        decimal TransactionAmount { get;  }
        DateTime CreatedDate { get;  }
        DateTime ModifiedDate { get;  }
        string CurrencyCode { get;  }
        string Merchant { get;  }
    }

    public class Transaction : ITransaction
    {
        public long TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CurrencyCode { get; set; }
        public string Merchant { get; set; }
    }
}