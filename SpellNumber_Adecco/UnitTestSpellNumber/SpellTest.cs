using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpellNumber;

namespace UnitTestSpellNumber
{
    [TestClass]
    public class SpellTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("Failed", "Failed");
        }

       
        [TestMethod]
        public void CheckSpellInvalid()
        {
            string myWord = Spell.ConvertToWords("54234.871");
            string myActual = "Fifty Four Thousand Two Hundred Thirty Four Rupees and Eighty Seven Paisa Only";
            Assert.AreNotEqual(myWord, myActual);

        }

        /// <summary>
        /// Test to check correct spell
        /// </summary>
        [TestMethod]
        public void CheckSpellValid()
        {
            string myWord = Spell.ConvertToWords("54234.87");
            string myActual = "Fifty Four Thousand Two Hundred Thirty Four Rupees and Eighty Seven Paisa Only";
            Assert.AreEqual(myWord, myActual);

        }

        [TestMethod]
        public void CheckSpellNegative()
        {
            string myWord = Spell.ConvertToWords("-54234.87");
            string myActual = "Value is negative";
            Assert.AreEqual(myWord, myActual);

        }
    }
}
