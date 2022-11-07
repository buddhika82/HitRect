using System;
using System.Collections.Generic;
using System.Text;

namespace Rectanagle
{
    public class Grid
    {
        #region constructors 
        /// <summary>
        /// Create a grid with size and creates its codes
        /// </summary>
        /// <param name="size"></param>
        public Grid(int size)
        {
            Size = size;           
            GridCodes = new List<Code>();
            Rects = new List<Rect>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    GridCodes.Add(new Code(i, j));                    
                }
            }
        }
        #endregion

        #region properties 
        /// <summary>
        ///Get codes defined in the grid
        /// </summary>
        public List<Code> GridCodes { get; }
        /// <summary>
        /// Get rectangles set to grid
        /// </summary>
        public List<Rect> Rects { get; }
        /// <summary>
        /// Get the size of the grid
        /// </summary>
        public int Size { get; }
        #endregion

        #region public methods
        /// <summary>
        /// Cheks rectangle with the grid in the given cordinates for a given size
        /// and send for allocation
        /// </summary>
        /// <param name="rectangle(width,height)"></param>
        /// <param name="startCode(x,y)"></param>
        /// <returns></returns>
        public bool AddRect(Rect rect, Code startCode)
        {
            if (IsCodeInGrid(startCode))
            {                
                if (DoesRectFitGrid(startCode, rect))
                {                   
                    return Alocate(rect, startCode);                   
                }                
            }           
            return false;
        }      

        /// <summary>
        /// Removes a rectanagle from the grid if it is falls in the given codes
        /// </summary>
        /// <param name="code(x,y)"></param>
        /// <returns></returns>
        public bool HitRect(Code code)
        {
            if (IsCodeInGrid(code))
            {
                foreach (Rect rect in Rects)
                {
                    bool exist = rect.RectCodes.Exists(c => c.x == code.x && c.y == code.y);
                    if (exist)
                    {
                        Rects.Remove(rect);
                        Console.WriteLine("Rectangle hit and removed sucessfully");
                        return true;
                    }
                }
                Console.WriteLine("No rectangle found in the given position.");
                return false;
            }
            return false;
        }
        #endregion

        #region private methods
        /// <summary>
        /// Allocate codes for the rectangle with in the grid and add the rectangle to grid
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="startCode"></param>
        /// <returns></returns>
        private bool Alocate(Rect rect, Code startCode)
        {           
            for (int i = 0; i < rect.Width; i++)
            {
                for (int j = 0; j < rect.Height; j++)
                {
                    Code code = new Code(startCode.x + i, startCode.y + j);
                    foreach (Rect r in Rects)
                    {
                        if (r.RectCodes.Exists(c => c.x == code.x && c.y == code.y))
                        {
                            Console.WriteLine("Rectangle overlaps another.");
                            return false;
                        }
                    }
                    rect.RectCodes.Add(code);
                }
            }
            this.Rects.Add(rect);
            Console.WriteLine("Rectangle added sucessfully.");
            return true;
        }

        /// <summary>
        /// Check if the code is with in the Grid
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private bool IsCodeInGrid(Code code)
        {
            if (code.x > Size || code.y > Size || code.x < 0 || code.y < 0)
            {
                Console.WriteLine("Code is off grids limites");
                return false;
            }
            Console.WriteLine("Code is with in grids limites");
            return true;
        }

        /// <summary>
        /// Check if the rectangle fits the grid
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private bool DoesRectFitGrid(Code code,Rect rect)
        {
            if ((code.x + rect.Width) <= Size && (code.y + rect.Height) <= Size)
            {
                Console.WriteLine("size with in the grid.");
                return true;
            }
            Console.WriteLine("size is off the grid.");
            return false;
        }
        #endregion

    }
}
