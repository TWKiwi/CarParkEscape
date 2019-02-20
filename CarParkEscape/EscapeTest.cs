using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarParkEscape
{
    [TestClass]
    public class EscapeTest
    {
        [TestMethod]
        public void EscapeFromGroundFloor()
        {
            var result = new Kata().Escape(
                new[,] { { 2, 0, 0, 0, 0 } });
            var excepted = new[] { "R4" };
            Assert.AreEqual(result, excepted);
        }
    }
}
