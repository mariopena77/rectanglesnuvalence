using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RectanglesNuvalence
{
    public class Rectangle
    {
        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private List<string> _validationMessages;

        /// <summary>
        /// Top of the Rectangle (Coordinate Y)
        /// </summary>
        public int Top { get { return _y; } }

        /// <summary>
        /// Bottom of the Rectangle (Coordinate Y)
        /// </summary>
        public int Bottom { get { return _y + _height; } }

        /// <summary>
        /// Left of the Rectangle (Coordinate X)
        /// </summary>
        public int Left { get { return _x; } }

        /// <summary>
        /// Right of the Rectangle (Coordinate X)
        /// </summary>
        public int Right { get { return _x + _width; } }

        /// <summary>
        /// Creates a Rectangle object
        /// </summary>
        /// <param name="x">Coordinate x of the Rectangle initial point</param>
        /// <param name="y">Coordinate y of the Rectangle initial point</param>
        /// <param name="width">Width of the Rectangle</param>
        /// <param name="height">Height of the Rectangle</param>
        /// <exception cref="Exception">Exception if tha values are invalid</exception>
        public Rectangle(int x, int y, int width, int height)
        {
            if (_validationMessages == null)
                _validationMessages = new List<string>();

            if (IsValid(x, y, width, height))
            {
                _x = x;
                _y = y;
                _width = width;
                _height = height;
            }
            else
            {
                string errorMessage = string.Empty;
                foreach (string error in _validationMessages)
                {
                    errorMessage += error + "\n";
                }
                throw new Exception(errorMessage);
            }
        }

        /// <summary>
        /// Determines if a rectangle is contained in this Rectangle
        /// </summary>
        /// <param name="rectangle">Rectangle to validate if it is contained</param>
        /// <returns>True if object rectangle is contained in this Rectangle, false otherwise</returns>
        public bool IsContained(Rectangle rectangle)
        {
            return PointIsInside(rectangle.Top, rectangle.Left) && PointIsInside(rectangle.Bottom, rectangle.Left) && PointIsInside(rectangle.Top, rectangle.Right) && PointIsInside(rectangle.Bottom, rectangle.Right);
        }

        /// <summary>
        /// Find all the lines adjacents between the rectangles
        /// </summary>
        /// <param name="rectangle">Rectanlge to validate against this Rectangle</param>
        /// <returns>List of messages describing the adjacent lines</returns>
        public List<string> FindAdjacents(Rectangle rectangle)
        {
            List<string> adjacents = new List<string>();

            //Check vertical left line
            if ((rectangle.Left == Left || rectangle.Left == Right) && (IsAdjacent(Top, _height, rectangle.Top, rectangle.Bottom - rectangle.Top)))
                adjacents.Add("Vertical left line is " + GetAdjacentMessage(rectangle.Top, rectangle.Bottom, Top, Bottom));

            //Check vertical right line
            if ((rectangle.Right == Left || rectangle.Right == Right) && (IsAdjacent(Top, _height, rectangle.Top, rectangle.Bottom - rectangle.Top)))
                adjacents.Add("Vertical right line is " + GetAdjacentMessage(rectangle.Top, rectangle.Bottom, Top, Bottom));

            //Check horizontal upper line
            if ((rectangle.Top == Top || rectangle.Top == Bottom) && (IsAdjacent(Left, _width, rectangle.Left, rectangle.Right - rectangle.Left)))
                adjacents.Add("Horizontal upper line is " + GetAdjacentMessage(rectangle.Left, rectangle.Right, Left, Right));

            //Check horizontal bottom line
            if ((rectangle.Bottom == Top || rectangle.Bottom == Bottom) && (IsAdjacent(Left, _width, rectangle.Left, rectangle.Right - rectangle.Left)))
                adjacents.Add("Horizontal bottom line is " + GetAdjacentMessage(rectangle.Left, rectangle.Right, Left, Right));

            return adjacents;
        }

        /// <summary>
        /// Find all the intersection points between the rectangles
        /// </summary>
        /// <param name="rectangle">Rectanlge to validate against this Rectangle</param>
        /// <returns>List of points that intersects between the rectangles</returns>
        public List<Point> IntersectsWith(Rectangle rectangle)
        {
            List<Point> intersectPoints = new List<Point>();
            int coordinateY = 0;
            int coordinateX = 0;

            //Check vertical left line        
            if (LineCrosses(rectangle.Top, rectangle.Left, rectangle.Bottom, rectangle.Left))
            {
                coordinateY = rectangle.Bottom > Bottom ? Bottom : Top;
                intersectPoints.Add(new Point(rectangle.Left, coordinateY));
            }

            //Check vertical right line
            if (LineCrosses(rectangle.Top, rectangle.Right, rectangle.Bottom, rectangle.Right))
            {
                coordinateY = rectangle.Top > Top ? Bottom : Top;
                intersectPoints.Add(new Point(rectangle.Right, coordinateY));
            }

            //Check horizontal upper line
            if (LineCrosses(rectangle.Top, rectangle.Left, rectangle.Top, rectangle.Right))
            {
                coordinateX = rectangle.Left > Left ? Right : Left;
                intersectPoints.Add(new Point(coordinateX, rectangle.Top));
            }

            //Check horizontal bottom line
            if (LineCrosses(rectangle.Bottom, rectangle.Left, rectangle.Bottom, rectangle.Right))
            {
                coordinateX = rectangle.Left > Left ? Right : Left;
                intersectPoints.Add(new Point(coordinateX, rectangle.Bottom));
            }

            return intersectPoints;
        }

        /// <summary>
        /// Build the message of adjacent lines, specifying the type of adjacent
        /// </summary>
        /// <param name="rectangleStart">First coordinate (x or y), where the line of the rectagngle to validate starts</param>
        /// <param name="rectangleEnd">Second coordinate (x or y), where the line of the rectagngle to validate ends</param>
        /// <param name="start">First coordinate (x or y), where the line of this Rectangle starts</param>
        /// <param name="end">Second coordinate (x or y), where the line if this Rectangle ends</param>
        /// <returns>Message describing the type of adjacency</returns>
        private string GetAdjacentMessage(int rectangleStart, int rectangleEnd, int start, int end)
        {
            string message = string.Empty;
            if (rectangleStart == start && rectangleEnd == end)
                message = "Adjacent (Proper)";
            else if (rectangleStart >= start && rectangleEnd <= end)
                message = "Adjacent (Sub-line)";
            else
                message = "Adjacent (Partial)";

            return message;
        }


        /// <summary>
        /// Determines if two lines (represented by its two points) share more than one point
        /// </summary>
        /// <param name="referenceStart">Start point of the line used as reference in the comparison</param>
        /// <param name="referenceSize">End point of the line used as reference in the comparison</param>
        /// <param name="comparedStart">Start point of the line to compare</param>
        /// <param name="comparedSize">End point of the line to compare</param>
        /// <returns></returns>
        private bool IsAdjacent(int referenceStart, int referenceSize, int comparedStart, int comparedSize)
        {
            var range1 = Enumerable.Range(referenceStart, referenceSize + 1).ToList();
            var range2 = Enumerable.Range(comparedStart, comparedSize + 1).ToList();
            var pointsInBoth = range1.Intersect(range2).ToList();

            return pointsInBoth.Count > 1 ? true : false;
        }

        /// <summary>
        /// Determines if a point is inside or outside the Rectangle
        /// </summary>
        /// <param name="x">Coordinate x of the point</param>
        /// <param name="y">Coordinate y of the point</param>
        /// <returns>True if the point is inside the Rectangle, false otherwise</returns>
        private bool PointIsInside(int x, int y)
        {
            return x > Top && x < Bottom && y > Left && y < Right;
        }

        /// <summary>
        /// Determines if a line crosses the Rectangle in some point
        /// </summary>
        /// <param name="x1">First coordinate x of the line</param>
        /// <param name="y1">First coordinate y of the line</param>
        /// <param name="x2">Second coordinate x of the line</param>
        /// <param name="y2">Second coordinate y of the line</param>
        /// <returns>True if the line crosses the Rectangle in some point</returns>
        private bool LineCrosses(int x1, int y1, int x2, int y2)
        {
            return (PointIsInside(x1, y1) && !PointIsInside(x2, y2)) || (!PointIsInside(x1, y1) && PointIsInside(x2, y2));
        }

        /// <summary>
        /// Validate the values used to create the Rectangle object are correct
        /// </summary>
        /// <param name="x">Coordinate x of the Rectangle initial point</param>
        /// <param name="y">Coordinate y of the Rectangle initial point</param>
        /// <param name="width">Width of the Rectangle</param>
        /// <param name="height">Height of the Rectangle</param>
        /// <returns>True if all the values are valida, false otherwise</returns>
        private bool IsValid(int x, int y, int width, int height)
        {
            if (x < 0 || y < 0 || width < 0 || height < 0)
                _validationMessages.Add("Values x, y, width and height must be all positive");

            if (width == 0)
                _validationMessages.Add("Width must be greater than 0");

            if (height == 0)
                _validationMessages.Add("Height must be greater than 0");

            if ((long)x + (long)width > Int32.MaxValue)
                _validationMessages.Add("The sum of x and width is greater than the maximum allowed");

            if ((long)y + (long)height > Int32.MaxValue)
                _validationMessages.Add("The sum of y and height is greater than the maximum allowed");

            return _validationMessages.Count <= 0;
        }
    }
}
