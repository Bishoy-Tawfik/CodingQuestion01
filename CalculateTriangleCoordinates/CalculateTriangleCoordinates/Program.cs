using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateTriangleCoordinates
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = ShowOptions();
                switch (input)
                {
                    case "1":
                        //Go to calculate the triangle coordinates functionality
                        CalculateTriangleCoordinatesForImage();
                        break;
                    case "2":
                        CalculateRowAndColumnForTriangle();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Undefined input!");
                        break;
                }
            }
        }

        private static string ShowOptions()
        {
            Console.WriteLine("To calculate the triangle coordinates for an image with right triangles press 1."
            + Environment.NewLine + "To calculate the row and column for the triangle press 2."
            + Environment.NewLine + "To Exit press 3.");
            string input = Console.ReadLine();
            return input;
        }

        private static void CalculateRowAndColumnForTriangle()
        {
            //I don't really need the six inputs below, I need only four
            //but I asked the user to enter the three coordinates to don't confuse him 
            //I think it's better to enter the values as full coordinates
            Console.WriteLine("Enter the value of v1x:");
            string inputv1x = Console.ReadLine();
            Console.WriteLine("Enter the value of v1y:");
            string inputv1y = Console.ReadLine();

            Console.WriteLine("Enter the value of v2x:");
            string inputv2x = Console.ReadLine();
            Console.WriteLine("Enter the value of v2y:");
            string inputv2y = Console.ReadLine();

            Console.WriteLine("Enter the value of v3x:");
            string inputv3x = Console.ReadLine();
            Console.WriteLine("Enter the value of v3y:");
            string inputv3y = Console.ReadLine();
            
            int v1x,v1y,v2x,v2y,v3x,v3y;
            bool areDigits = MakeSureCoordinatesAreDigits(inputv1x, inputv1y, inputv2x, 
                inputv2y, inputv3x, inputv3y, out v1x, out v1y, out v2x, out v2y, out v3x, out v3y);
            if (!areDigits)
            {
                Console.WriteLine("Coordinates have to be digits!");
                return;
            }
            int startColumn = (int)v1x / 5;
            int endColumn = (int)v3x / 5;
            //char startLetter = char. (int)v2y/10 + 64
            string startLetter = "";
            int startLetterIndex = (int)v2y / 10 - 1;
            if (startLetterIndex < 0)
                startLetterIndex = 0;
            int endLetterIndex = (int)v1y / 10 - 1;
            if (endLetterIndex < 0)
                endLetterIndex = 0;
            startLetter = (char)((char)'A' + startLetterIndex) + startLetter;
            string endLetter = "";
            endLetter = (char)((char)'A' + endLetterIndex) + endLetter;
            Console.WriteLine("The triangle starts at the column: {0}, and ends at the column {1}.", startColumn, endColumn);
            Console.WriteLine("The triangle starts at the row: {0}, and ends at the row {1}.", startLetter, endLetter);
        }

        private static bool MakeSureCoordinatesAreDigits(string inputv1x, string inputv1y, 
            string inputv2x, string inputv2y, string inputv3x, string inputv3y, out int v1x,
            out int v1y, out int v2x, out int v2y, out int v3x, out int v3y)
        {
            v1x = 0;
            v2x = 0;
            v3x = 0;
            v1y = 0;
            v2y = 0;
            v3y = 0;

            bool isDigit = int.TryParse(inputv1x, out v1x);
            if(isDigit)
            {
                isDigit = int.TryParse(inputv1y, out v1y);
                if(isDigit)
                {
                    isDigit = int.TryParse(inputv2x, out v2x);
                    if (isDigit)
                    {
                        isDigit = int.TryParse(inputv2y, out v2y);
                        if (isDigit)
                        {
                            isDigit = int.TryParse(inputv3x, out v3x);
                            if (isDigit)
                            {
                                isDigit = int.TryParse(inputv3y, out v3y);
                            }
                        }
                    }
                }
            }
            return isDigit;
        }

        private static void CalculateTriangleCoordinatesForImage()
        {
            Console.WriteLine("Enter the number of columns:");
            string inputColumnNumber = Console.ReadLine();
            Console.WriteLine("Enter the letter of the last letter for the triangle:");
            string inputRowLetter = Console.ReadLine();
            int columnNumber = 0;
            bool isDigit = int.TryParse(inputColumnNumber, out columnNumber);
            if (!isDigit)
            {
                Console.WriteLine("Column number has to be only digits!");
                return;
            }
            if (inputRowLetter.Length > 1 || !char.IsLetter(inputRowLetter, 0))
            {
                Console.WriteLine("The row has to be a letter!");
                return;
            }
            char rowLetter = char.Parse(inputRowLetter);
            for (char c = 'A'; c <= char.ToUpper(rowLetter)+1; c++)
            {
                int y = char.ToUpper(c) - 65;
                for (int i = 0; i <= columnNumber; i++)
                {
                    int colValue =i * 5;
                    if ((colValue / 5) % 2 == 0)
                    {
                        Console.Write("(v+" + colValue + "," + "v+" + y * 10 + ")");
                        Console.Write("     ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
