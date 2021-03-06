﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartMenuLibrary;
using System.IO;

namespace SmartMenuTest
{
    [TestClass]
    public class TestVersion1
    {
        private SmartMenu menu;

        [TestInitialize]
        public void SetupForTest()
        {
            menu = new SmartMenu();
            menu.LoadMenu(true);
        }
        [TestMethod]
        public void TestFilesFound()
        {
            Assert.AreEqual("TestDansk.txt", menu.fileNames[0]);
            Assert.AreEqual("TestDeutsch.txt", menu.fileNames[1]);
            Assert.AreEqual("TestEnglish.txt", menu.fileNames[2]);
            Assert.AreEqual("TestFrançais.txt", menu.fileNames[3]);
        }
        [TestMethod]
        public void TestMenuIDload()
        {
            Assert.AreEqual("DoThis", menu.menuID[0]);
        }
        [TestMethod]
        public void TestMenuListLoad()
        {
            Assert.AreEqual("Do this", menu.menuList[0]);
        }
        [TestMethod]
        public void TestMenuNameload()
        {
            Assert.AreEqual("My Fantastic Menu", menu.menuName);
        }
        [TestMethod]
        public void TestMenuDescriptionLoad()
        {
            Assert.AreEqual("(Press Menu number or 0 to exit)", menu.menuDescription);
        }
        [TestMethod]
        public void TestErrorsShouldBeEnglish()
        {
            Assert.AreEqual(" could not be found...", menu.errors[0]);
            Assert.AreEqual("ERROR 1: Invalid input", menu.errors[1]);
            Assert.AreEqual("ERROR 2: This is not a menu", menu.errors[2]);
        }
        [TestMethod]
        public void TestErrorsShouldStillBeEnglish()
        {
            menu.SetErrors(@"TestEnglishe.txt");
            Assert.AreEqual(" could not be found...", menu.errors[0]);
            Assert.AreEqual("ERROR 1: Invalid input", menu.errors[1]);
            Assert.AreEqual("ERROR 2: This is not a menu", menu.errors[2]);
        }
        [TestMethod]
        public void TestErrorsShouldBeFrench()
        {
            menu.SetErrors(@"TestFrançais.txt");
            Assert.AreEqual(" blah blah blah", menu.errors[0]);
            Assert.AreEqual("ERROR 1: blah blah blah", menu.errors[1]);
            Assert.AreEqual("ERROR 2: blah blah blah", menu.errors[2]);
        }
    }
}
