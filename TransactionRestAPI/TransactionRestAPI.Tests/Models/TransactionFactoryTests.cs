using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactionRestAPI.Models;

namespace TransactionRestAPI.Tests.Models
{
    [TestClass]
    public class TransactionFactoryTests
    {
        [TestMethod]
        public void TransactionFactoryInstanceTest()
        {
            TransactionFactory tf = TransactionFactory.Instance();
            Assert.IsNotNull(tf);
        }

        [TestMethod]
        public void TransactionFactoryTransactionsTest()
        {
            TransactionFactory tf = TransactionFactory.Instance();
            IList<ITransaction> tl = tf.Transactions();

            Assert.IsNotNull(tf);
            Assert.AreEqual(0, tl.Count);
        }

        static String _currency = "GBP";
        static String _merchant = "MoneyBox";
        static String _desc = "Test Create";
        static Decimal _amount = 12.56M;
        static DateTime _tdate = DateTime.Now;

        [TestMethod]
        public void TransactionFactoryCreateTest()
        {
            TransactionFactory tf = TransactionFactory.Instance();
            Transaction input = new Transaction();
            input.CurrencyCode = _currency;
            input.Description = _desc;
            input.Merchant = _merchant;
            input.TransactionAmount = _amount;
            input.TransactionDate = _tdate;

            ITransaction output = tf.Create(input);

            Assert.IsNotNull(output);
            Assert.AreEqual(1, output.TransactionId);
            Assert.IsTrue(output.CreatedDate >= _tdate && output.CreatedDate <= DateTime.Now,
                String.Format("CreationDateTest {0} >= {1} <= {2}", output.ModifiedDate, _tdate, DateTime.Now));
            Assert.AreEqual(output.CreatedDate, output.ModifiedDate);
            Assert.AreEqual(_currency, output.CurrencyCode);
            Assert.AreEqual(_merchant, output.Merchant);
            Assert.AreEqual(_desc, output.Description);
            Assert.AreEqual(_amount, output.TransactionAmount);
        }

        [TestMethod]
        public void TransactionFactoryGetTest()
        {
            TransactionFactory tf = TransactionFactory.Instance();
            long input = 1;

            ITransaction output = tf.Get(input);

            Assert.IsNotNull(output);
            Assert.AreEqual(1, output.TransactionId);
            Assert.IsTrue(output.CreatedDate > _tdate && output.CreatedDate < DateTime.Now);
            Assert.AreEqual(output.CreatedDate, output.ModifiedDate);
            Assert.AreEqual(_currency, output.CurrencyCode);
            Assert.AreEqual(_merchant, output.Merchant);
            Assert.AreEqual(_desc, output.Description);
            Assert.AreEqual(_amount, output.TransactionAmount);
        }

        [TestMethod]
        public void TransactionFactoryUpdateTest()
        {
            String  currency = "USD";
            String  merchant = "IG Group";
            String  desc = "Test Update";
            Decimal amount = 56.12M;
            DateTime tdate = DateTime.Now;

            TransactionFactory tf = TransactionFactory.Instance();
            ITransaction output = tf.Get (1);

            Transaction input = new Transaction();
            input.TransactionId = output.TransactionId;
            input.CurrencyCode = currency;
            input.Description = desc;
            input.Merchant = merchant;
            input.TransactionAmount = amount;
            input.TransactionDate = output.TransactionDate;

            output = tf.Update(input);

            Assert.IsNotNull(output);
            Assert.IsTrue(output.ModifiedDate >= tdate && output.ModifiedDate <= DateTime.Now, 
                String.Format("CreationDateTest {0} >= {1} <= {2}", output.ModifiedDate, tdate, DateTime.Now));
            Assert.IsTrue(output.CreatedDate <= output.ModifiedDate, String.Format("ModifiedDateTest {0} <= {1}", output.CreatedDate, output.ModifiedDate));
            Assert.AreEqual(currency, output.CurrencyCode);
            Assert.AreEqual(merchant, output.Merchant);
            Assert.AreEqual(desc, output.Description);
            Assert.AreEqual(amount, output.TransactionAmount);
        }

        [TestMethod]
        public void TransactionFactoryDeleteTest()
        {
            TransactionFactory tf = TransactionFactory.Instance();
            long input = 1;
            int preCount = tf.Transactions().Count;
            ITransaction output = tf.Delete(input);

            Assert.IsNotNull(output);
            Assert.AreEqual(preCount, tf.Transactions().Count + 1);
            Assert.AreEqual(1, output.TransactionId);
            Assert.IsNull(tf.Get(output.TransactionId));
        }
    }
}
