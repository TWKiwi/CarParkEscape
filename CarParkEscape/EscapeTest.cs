using ExpectedObjects;
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

        [TestMethod]
        public void EscapeFromGroundFloor_Ver3()
        {
            var result = new Kata().Escape(
                new[,] { { 1, 0, 0, 0, 0 }, { 0, 2, 0, 0, 0 } });
            var excepted = new[] { "R3" }.ToExpectedObject();
            excepted.ShouldEqual(result);
        }

        [TestMethod]
        public void EscapeFromSecondFloor_Ver1()
        {
            var result = new Kata().Escape(
                new[,] { { 1, 0, 0, 0, 2 },
                    { 0, 0, 0, 0, 0 } });
            var excepted = new[] { "L4", "D1", "R4" }.ToExpectedObject();
            excepted.ShouldEqual(result);
        }

        [TestMethod]
        public void EscapeFromSecondFloor_Ver2()
        {
            var result = new Kata().Escape(
                new[,] { { 0, 1, 2, 0, 0 },
                    { 0, 0, 0, 0, 0 } });
            var excepted = new[] { "L1", "D1", "R3" }.ToExpectedObject();
            excepted.ShouldEqual(result);
        }

        [TestMethod]
        public void EscapeFromSecondFloor_Ver3()
        {
            var result = new Kata().Escape(
                new[,] { { 2, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 } });
            var excepted = new[] { "R1", "D1", "R3" }.ToExpectedObject();
            excepted.ShouldEqual(result);
        }

        [TestMethod]
        public void EscapeFromSecondFloor_Ver4()
        {
            var result = new Kata().Escape(
                new[,] { { 1, 0, 0, 0, 0 },{ 2, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 } });
            var excepted = new[] { "R1", "D1", "R3" }.ToExpectedObject();
            excepted.ShouldEqual(result);
        }

        [TestMethod]
        public void EscapeFromThirdFloor_Ver1()
        {
            var result = new Kata().Escape(
                new[,] { { 1, 0, 0, 0, 2 },{ 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 } });
            var excepted = new[] { "L4", "D1", "R1", "D1", "R3" }.ToExpectedObject();
            excepted.ShouldEqual(result);
        }

        [TestMethod]
        public void EscapeFromThirdFloor_Ver2()
        {
            var result = new Kata().Escape(
                new[,] { { 2, 0, 0, 0, 1 },{ 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 } });
            var excepted = new[] { "R4", "D1", "L3", "D1", "R3" }.ToExpectedObject();
            excepted.ShouldEqual(result);
        }

        [TestMethod]
        public void EscapeFromThirdFloor_Ver3()
        {
            var result = new Kata().Escape(
                new[,] { { 2, 1, 0, 0, 0 },{ 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 } });
            var excepted = new[] { "R1", "D1", "D1", "R3" }.ToExpectedObject();
            excepted.ShouldEqual(result);
        }

    }
}
