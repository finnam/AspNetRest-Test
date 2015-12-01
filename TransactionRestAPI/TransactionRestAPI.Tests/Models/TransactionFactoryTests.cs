using System;
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
        public void TransactionFactoryCreate()
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
            Assert.IsTrue(output.CreatedDate > _tdate && output.CreatedDate < DateTime.Now);
            Assert.AreEqual(output.CreatedDate, output.ModifiedDate);
            Assert.AreEqual(_currency, output.CurrencyCode);
            Assert.AreEqual(_merchant, output.Merchant);
            Assert.AreEqual(_desc, output.Description);
            Assert.AreEqual(_amount, output.TransactionAmount);
        }

        [TestMethod]
        public void TransactionFactoryGet()
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
    }
}
