using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rectanagle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rectangle.Test
{
    [TestClass]
    public class UnitTestRect
    {
        [TestMethod]
        public void TestCreateRect()
        {
            Rect c = new Rect(1, 2);
        }
    }
}
