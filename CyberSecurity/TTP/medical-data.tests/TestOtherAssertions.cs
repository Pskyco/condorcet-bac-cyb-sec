using System;
using NUnit.Framework;

namespace medical_data.tests
{
    public class TestOtherAssertions
    {
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-546846846)]
        [TestCase(-545646)]
        public void TestTrueIfUnder2_ValidCases(int number)
        {
            Assert.IsTrue(TrueIfUnder2(number));
            Assert.That(TrueIfUnder2(number) == true);
            Assert.AreEqual(true, TrueIfUnder2(number));
            Assert.AreNotEqual(false, TrueIfUnder2(number));
        }
        
        [TestCase(2)]
        [TestCase(9)]
        [TestCase(1454565)]
        [TestCase(898977798)]
        [TestCase(516488976)]
        public void TestTrueIfUnder2_InvalidCases(int number)
        {
            Assert.IsFalse(TrueIfUnder2(number));
        }
        
        // bad way
        // [Test]
        // public void TestTrueIfUnder2_ValidCases()
        // {
        //     Assert.IsTrue(TrueIfUnder2(1));
        //     Assert.IsTrue(TrueIfUnder2(0));
        //     Assert.IsTrue(TrueIfUnder2(-1));
        //     Assert.IsTrue(TrueIfUnder2(-546846846));
        //     Assert.IsTrue(TrueIfUnder2(-545646));
        // }
        
        public bool TrueIfUnder2(int number)
        {
            // if (number < 2)
            //     return true;
            //
            // return false;

            // return number < 2 ? true : false;

            return number < 2;
        }

        [Test]
        public void TestIWillThrow_Works()
        {
            Assert.Throws<Exception>(IWillThrow);
        }

        public void IWillThrow()
        {
            throw new Exception();
        }
        
        [Test]
        public void TestIWillThrowWithMessage_Works()
        {
            Assert.Throws<Exception>(IWillThrowWithMessage, "I thrown");
        }

        public void IWillThrowWithMessage()
        {
            throw new Exception("I thrown");
        }
    }
}