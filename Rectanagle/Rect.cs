using System;
using System.Collections.Generic;
using System.Text;

namespace Rectanagle
{
    public class Rect
    {
        #region constructors
        public Rect(int width, int height)
        {
            Height = width;
            Width = height;
            RectCodes = new List<Code>();
        }
        #endregion

        #region properties
        public List<Code> RectCodes { get;set; }
        public int Height { get; }
        public int Width { get;  }
        #endregion
    }
}
