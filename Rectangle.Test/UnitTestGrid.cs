using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rectanagle;

namespace Rectangle.Test
{
    [TestClass]
    public class UnitTestGrid
    {
        [TestMethod]
        public void TestCreateGrid()
        {
            Grid g = new Grid(5);            
        }

        [TestMethod]
        public void TestAddRect()
        {
            Grid g = new Grid(5);
            Code c = new Code(1, 2);
            Rect r = new Rect(1, 3);
            g.AddRect(r, c);
        }

        [TestMethod]
        public void TestHitRect()
        {
            Grid g = new Grid(5);
            Code c = new Code(1, 2);
            Rect r = new Rect(1, 3);
            g.AddRect(r, c);
            g.HitRect(c);
        }
    }
}
