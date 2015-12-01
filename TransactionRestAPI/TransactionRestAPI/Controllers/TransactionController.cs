using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TransactionRestAPI.Models;

namespace TransactionRestAPI.Controllers
{
    public class TransactionController : ApiController
    {
        // GET: api/Transaction
        public IEnumerable<Transaction> Get()
        {
            return new Transaction[] { new Transaction(), new Transaction() };
        }

        // GET: api/Transaction/5
        public Transaction Get(int id)
        {
            return null;
        }

        // POST: api/Transaction
        public void Post([FromBody]Transaction value)
        {
        }

        // PUT: api/Transaction/5
        public void Put(int id, [FromBody]Transaction value)
        {
        }

        // DELETE: api/Transaction/5
        public void Delete(int id)
        {
        }
    }
}
