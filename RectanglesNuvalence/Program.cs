using System.Drawing;

namespace RectanglesNuvalence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userContinue = "y";

            while (userContinue.ToLower() == "y")
            {
                try
                {
                    GetValues();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("The rectangle could not be created: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("");
                    Console.WriteLine("Do you want to continue (y/n)?");
                    userContinue = Console.ReadLine();
                    Console.WriteLine("");
                }

            }

        }

        /// <summary>
        /// Get the values from the user
        /// </summary>
        static void GetValues()
        {

            int x1 = GetInteger("Coordinate x (upper left corner) of Rectangle 1 initial point:");
            int y1 = GetInteger("Coordinate y (upper left corner) of Rectangle 1 initial point:");
            int width1 = GetInteger("Width of Rectangle 1:");
            int height1 = GetInteger("Height of Rectangle 1:");
            Rectangle rectangle1 = new Rectangle(x1, y1, width1, height1);

            int x2 = GetInteger("Coordinate x (upper left corner) of Rectangle 2 initial point:");
            int y2 = GetInteger("Coordinate y (upper left corner) of Rectangle 2 initial point:");
            int width2 = GetInteger("Width of Rectangle 2:");
            int height2 = GetInteger("Height of Rectangle 2:");
            Rectangle rectangle2 = new Rectangle(x2, y2, width2, height2);

            Console.WriteLine("");

            ShowIntersections(rectangle1, rectangle2);
            ShowContainment(rectangle1, rectangle2);
            ShowAdjacency(rectangle1, rectangle2);

        }

        /// <summary>
        /// Receives the entry of the user and assure there are integers
        /// </summary>
        /// <param name="message">message to show to user</param>
        /// <returns>Value entered by the user</returns>
        static int GetInteger(string message)
        {
            Console.WriteLine(message);
            string data = Console.ReadLine();
            int value;
            while (!Int32.TryParse(data, out value))
            {
                Console.WriteLine("The value must be an integer");
                data = Console.ReadLine();
            }

            return value;
        }

        /// <summary>
        /// Shows the intersection points between the rectangles
        /// </summary>
        /// <param name="rectangle1">Rectangle 1</param>
        /// <param name="rectangle2">Rectangle 2</param>
        static void ShowIntersections(Rectangle rectangle1, Rectangle rectangle2)
        {
            List<Point> intersections = rectangle1.IntersectsWith(rectangle2);
            if (intersections.Count > 0)
            {
                foreach (Point point in intersections)
                {
                    Console.WriteLine("Point of intersection: " + point.X.ToString() + "," + point.Y.ToString());
                }
            }
            else
            {
                Console.WriteLine("There are no points of intersection");
            }
        }

        /// <summary>
        /// Shows if rectangle2 is contained in rectangle1
        /// </summary>
        /// <param name="rectangle1">Rectangle 1</param>
        /// <param name="rectangle2">Rectangle 2</param>
        static void ShowContainment(Rectangle rectangle1, Rectangle rectangle2)
        {
            if (rectangle1.IsContained(rectangle2))
                Console.WriteLine("Rectangle 2 is contained in Rectangle 1");
            else
                Console.WriteLine("Rectangle 2 is NOT contained in Rectangle 1");
        }

        /// <summary>
        /// Shows the adjacency lines found between the rectangles
        /// </summary>
        /// <param name="rectangle1">Rectangle 1</param>
        /// <param name="rectangle2">Rectangle 2</param>
        static void ShowAdjacency(Rectangle rectangle1, Rectangle rectangle2)
        {
            List<string> adjacents = rectangle1.FindAdjacents(rectangle2);
            if (adjacents.Count > 0)
            {
                foreach (string message in adjacents)
                {
                    Console.WriteLine(message);
                }
            }
            else
            {
                Console.WriteLine("There are no adjacent lines");
            }

        }
    }
}