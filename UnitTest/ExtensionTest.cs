using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;
using Domain.Utility;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class ExtensionTest
    {
        private static TestData[] _testData = new[]
        {
            new TestData() {PunchDate = new DateTime(2010, 7, 8), ExpectedResult = "Thursday, 08 July 2010 00: 00 AM"},
            new TestData() {PunchDate = new DateTime(2011, 7, 8), ExpectedResult = "Friday, 08 July 2011 00: 00 AM"}
        };

        [Test]
        [TestCase(2, ActionType.Comment, ExpectedResult = "2  comments ")]
        [TestCase(1, ActionType.EnterTheRoom, ExpectedResult = "1  person  entered ")]
        [TestCase(3, ActionType.HighFive, ExpectedResult = "3  people  high-fived ")]
        public string HistoryHourlyInText(int actionCount, ActionType actionType)
        {
            return "".GetHistoryHourlyInText(actionCount, actionType);
        }

        [Test]
        public void FormatDateTime([ValueSource("_testData")] TestData testData)
        {
            Assert.AreEqual(testData.PunchDate.FormatDateTime(), testData.ExpectedResult);
        }
    }

    public class TestData
    {
        public DateTime PunchDate { get; set; }
        public string ExpectedResult { get; set; }
    }
}
