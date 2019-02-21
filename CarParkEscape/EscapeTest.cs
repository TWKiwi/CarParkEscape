﻿using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarParkEscape
{
    [TestClass]
    public class EscapeTest
    {
        [TestMethod]
        public void EscapeFromGroundFloor_Ver1()
        {
            var result = new Kata().Escape(
                new[,] { { 2, 0, 0, 0, 0 } });
            var excepted = new[] { "R4" }.ToExpectedObject();
            excepted.ShouldEqual(result);
        }

        [TestMethod]
        public void EscapeFromGroundFloor_Ver2()
        {
            var result = new Kata().Escape(
                new[,] { { 0, 2, 0, 0, 0 } });
            var excepted = new[] { "R3" }.ToExpectedObject();
            excepted.ShouldEqual(result);
        }
    }
}