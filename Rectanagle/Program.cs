using System;

namespace Rectanagle
{
    class Program
    {
        private const int _minSize = 5;
        private const int _maxSize = 25;

        #region Methods
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Welcome to shoot rectanagle game");
            DefineGrid();           
            Console.WriteLine("Thank you for playing hit rectangle");
            Console.Read();
        }

        private static void  DefineGrid() {
            try
            {
            grid:
                Console.WriteLine("Enter Grid Size between 5 and 25 to continue");
                string gridSize = Console.ReadLine();
                int size = Convert.ToInt16(gridSize);
                if (size >= _minSize && size <= _maxSize)
                {
                    Grid plate = new Grid(size);
                    Console.WriteLine("Grid created of size" + plate.Size.ToString());
                    DefineRect(plate);
                    Shoot(plate);
                }
                else
                {
                    Console.WriteLine("Grid size must be between 5 and 25");
                    goto grid;
                }
            }
            catch (Exception ex){
                Console.WriteLine("An error occured during the process:Details as follows");
                Console.WriteLine(ex.ToString());
            }
        }

        private static void Shoot(Grid plate)
        {
            shot:
            Console.WriteLine("Enter Code to shoot 'x y'");
            string cordinates = Console.ReadLine();           
            string[] numbers = cordinates.Split(' ');          
            Code code = new Code(int.Parse(numbers[0]), int.Parse(numbers[1]));
            plate.HitRect(code);
            Console.WriteLine("Do you want to shoot again y/n");
            string response = Console.ReadLine();
            if (response == "y")
                goto shot;
        }

        private static void DefineRect(Grid plate)
        {
            top:
            Console.WriteLine("Enter Rect size position 'w h|x y'");
            string line = Console.ReadLine();
            string[] objects = line.Split('|');
            string[] rectSize = objects[0].Split(' ');
            Rect rectangle = new Rect(int.Parse(rectSize[0]), int.Parse(rectSize[1]));
            string[] cordinates = objects[1].Split(' ');
            Code code = new Code(int.Parse(cordinates[0]), int.Parse(cordinates[1]));
            plate.AddRect(rectangle, code);
            Console.WriteLine("Do you want to define another rectangle y/n");
            string response = Console.ReadLine();
            if (response == "y")
                goto top;
        }
        #endregion
    }
}
