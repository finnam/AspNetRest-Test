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
            TransactionFactory tf= TransactionFactory.Instance();

            return tf.Transactions().Select(t=>t as Transaction);
        }

        // GET: api/Transaction/5
        public IHttpActionResult Get(int id)
        {
            TransactionFactory tf = TransactionFactory.Instance();

            Transaction t = tf.Get(id) as Transaction;
            if ( t == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(t);
            }
        }

        // POST: api/Transaction
        public Transaction Post([FromBody]Transaction value)
        {
            TransactionFactory tf = TransactionFactory.Instance();

            return tf.Create(value) as Transaction;
        }

        // PUT: api/Transaction/5
        public Transaction Put([FromBody]Transaction value)
        {
            TransactionFactory tf = TransactionFactory.Instance();

            return tf.Update(value) as Transaction;
        }

        // DELETE: api/Transaction/5
        public IHttpActionResult Delete(int id)
        {
            TransactionFactory tf = TransactionFactory.Instance();

            ITransaction t = tf.Delete(id);
            if (t == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(t as Transaction);
            }
        }
    }
}
