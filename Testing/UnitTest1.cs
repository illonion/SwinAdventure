/*
 * File: NunitTemplate.cs
 * Author: Joshua Wright
 * Date: 16/08/2019
 * Unit: COS20007 Object Oriented Programming
 * Institution: Swinburne University of Technology
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //Don't forget this.
using SwinAdventure;

namespace SwinAdventure //Rename this to the namespace of your project.
{
    [TestFixture]
    public class TestIdentifiableObject //Rename this appropriately.
    {

        private IdentifiableObject _testObject;
        private IdentifiableObject _testObject2;

        [SetUp]
        public void SetUp()
        {
            _testObject = new IdentifiableObject(new string[] { "fred", "bob" });
            _testObject2 = new IdentifiableObject(new string[] { "" });
        }

        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(_testObject.AreYou("fred"));
            Assert.IsTrue(_testObject.AreYou("bob"));
        }

        [Test]
        public void TestNotAreYou()
        {
            Assert.IsFalse(_testObject.AreYou("wilma"));
            Assert.IsFalse(_testObject.AreYou("boby"));
        }

        [Test]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(_testObject.AreYou("FrED"));
            Assert.IsTrue(_testObject.AreYou("bOB"));
        }

        [Test]
        public void TestFirstID()
        {
            Assert.AreEqual(_testObject.FirstID, "fred");
        }

        [Test]
        public void TestNoneFirstID()
        {
            Assert.AreEqual(_testObject2.FirstID, "");
        }

        [Test]
        public void TestAddID()
        {
            _testObject.AddIdentifier("wilma");
            Assert.IsTrue(_testObject.AreYou("fred"));
            Assert.IsTrue(_testObject.AreYou("bob"));
            Assert.IsTrue(_testObject.AreYou("wilma"));
        }


    }
}