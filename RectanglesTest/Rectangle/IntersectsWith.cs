using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RectanglesNuvalence;

namespace RectangleTest.Rectangle
{
    [TestClass]
    public class IntersectsWith
    {
        [TestMethod]
        public void Rectangle2IsEqual()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);

            List<Point> points = rect1.IntersectsWith(rect2);

            Assert.AreEqual(0, points.Count);
        }

        [TestMethod]
        public void Rectangle2IsContained()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(1, 1, 3, 3);

            List<Point> points = rect1.IntersectsWith(rect2);

            Assert.AreEqual(0, points.Count);
        }

        [TestMethod]
        public void Rectangle2DoesNotIntersect()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 3, 3);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(5, 5, 3, 3);

            List<Point> points = rect1.IntersectsWith(rect2);

            Assert.AreEqual(0, points.Count);
        }

        [TestMethod]
        public void Rectangle2IntersectsRightAndBottomLines()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(2, 2, 5, 5);

            List<Point> points = rect1.IntersectsWith(rect2);

            Assert.AreEqual(2, points.Count);
            Assert.AreEqual(2, points[0].X);
            Assert.AreEqual(5, points[0].Y);
            Assert.AreEqual(5, points[1].X);
            Assert.AreEqual(2, points[1].Y);
        }

        [TestMethod]
        public void Rectangle2IntersectsLeftAndUpperLines()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(2, 2, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);

            List<Point> points = rect1.IntersectsWith(rect2);

            Assert.AreEqual(2, points.Count);
            Assert.AreEqual(5, points[0].X);
            Assert.AreEqual(2, points[0].Y);
            Assert.AreEqual(2, points[1].X);
            Assert.AreEqual(5, points[1].Y);
        }

        [TestMethod]
        public void Rectangle2IntersectsBottomLineTwice()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(2, 2, 1, 5);

            List<Point> points = rect1.IntersectsWith(rect2);

            Assert.AreEqual(2, points.Count);
            Assert.AreEqual(2, points[0].X);
            Assert.AreEqual(5, points[0].Y);
            Assert.AreEqual(3, points[1].X);
            Assert.AreEqual(5, points[1].Y);
        }

        [TestMethod]
        public void Rectangle2IntersectsUpperLineTwice()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(2, 2, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(3, 1, 2, 2);

            List<Point> points = rect1.IntersectsWith(rect2);

            Assert.AreEqual(2, points.Count);
            Assert.AreEqual(3, points[0].X);
            Assert.AreEqual(2, points[0].Y);
            Assert.AreEqual(5, points[1].X);
            Assert.AreEqual(2, points[1].Y);
        }

        [TestMethod]
        public void Rectangle2IntersectsRightLineTwice()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(2, 2, 4, 1);

            List<Point> points = rect1.IntersectsWith(rect2);

            Assert.AreEqual(2, points.Count);
            Assert.AreEqual(5, points[0].X);
            Assert.AreEqual(2, points[0].Y);
            Assert.AreEqual(5, points[1].X);
            Assert.AreEqual(3, points[1].Y);
        }

    }
}
