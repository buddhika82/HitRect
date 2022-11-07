using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rectanagle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rectangle.Test
{
    [TestClass]
    public class UnitTestCode
    {
        [TestMethod]
        public void TestCreateCode()
        {
            Code c = new Code(1, 2);
        }        
    }
}
