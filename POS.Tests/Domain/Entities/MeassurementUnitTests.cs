using POS.Core.Domain.Entities;
using POS.Core.Domain.Exceptions;

namespace POS.Tests.Domain.Entities
{
    [TestClass]
    public class MeassurementUnitTests
    {
        [TestMethod]
        public void Constructor_NameNull_ThrowsException()
        {
            Assert.ThrowsExactly<BusinessRuleException>(() =>
            {
                new MeasurementUnit(null!, "x");
            });
        }

        [TestMethod]
        public void Constructor_AbbreviationNull_ThrowsException()
        {
            Assert.ThrowsExactly<BusinessRuleException>(() =>
            {
                new MeasurementUnit("x", null!);
            });
        }

        [TestMethod]
        public void Constructor_NameEmpty_ThrowsException()
        {
            Assert.ThrowsExactly<BusinessRuleException>(() =>
            {
                new MeasurementUnit("", "x");
            });
        }

        [TestMethod]
        public void Constructor_AbbreviationEmpty_ThrowsException()
        {
            Assert.ThrowsExactly<BusinessRuleException>(() =>
            {
                new MeasurementUnit("x", "");
            });
        }

        [TestMethod]
        public void Constructor_NameWhiteSpace_ThrowsException()
        {
            Assert.ThrowsExactly<BusinessRuleException>(() =>
            {
                new MeasurementUnit("  ", "x");
            });
        }

        [TestMethod]
        public void Constructor_AbbreviationWhiteSpace_ThrowsException()
        {
            Assert.ThrowsExactly<BusinessRuleException>(() =>
            {
                new MeasurementUnit("x", "  ");
            });
        }

        [TestMethod]
        public void Constructor_NameTooLong_ThrowsException()
        {
            Assert.ThrowsExactly<BusinessRuleException>(() =>
            {
                new MeasurementUnit("ababababababababababa", "x");
            });
        }

        [TestMethod]
        public void Constructor_AbbreviationTooLong_ThrowsException()
        {
            Assert.ThrowsExactly<BusinessRuleException>(() =>
            {
                new MeasurementUnit("x", "abab");
            });
        }
    }
}
