using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RectanglesNuvalence;

namespace RectangleTest.Rectangle
{
    [TestClass]
    public class FindAdjacents
    {
        [TestMethod]
        public void Rectangle2IsContained()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(1, 1, 3, 3);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(0, adjacents.Count);
        }

        [TestMethod]
        public void Rectangle2IsEqual()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(4, adjacents.Count);
            Assert.AreEqual("Vertical left line is Adjacent (Proper)", adjacents[0]);
            Assert.AreEqual("Vertical right line is Adjacent (Proper)", adjacents[1]);
            Assert.AreEqual("Horizontal upper line is Adjacent (Proper)", adjacents[2]);
            Assert.AreEqual("Horizontal bottom line is Adjacent (Proper)", adjacents[3]);
        }

        [TestMethod]
        public void RightLineIsAdjacentProper()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(2, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(0, 0, 2, 5);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(1, adjacents.Count);
            Assert.AreEqual("Vertical right line is Adjacent (Proper)", adjacents[0]);
        }

        [TestMethod]
        public void LeftLineIsAdjacentProper()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(2, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(7, 0, 5, 5);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(1, adjacents.Count);
            Assert.AreEqual("Vertical left line is Adjacent (Proper)", adjacents[0]);
        }

        [TestMethod]
        public void BottomLineIsAdjacentProper()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(2, 1, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(2, 0, 5, 1);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(1, adjacents.Count);
            Assert.AreEqual("Horizontal bottom line is Adjacent (Proper)", adjacents[0]);
        }

        [TestMethod]
        public void UpperLineIsAdjacentProper()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(2, 2, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(2, 7, 5, 5);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(1, adjacents.Count);
            Assert.AreEqual("Horizontal upper line is Adjacent (Proper)", adjacents[0]);
        }

        [TestMethod]
        public void LeftLineIsAdjacentSubLine()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(5, 1, 1, 1);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(1, adjacents.Count);
            Assert.AreEqual("Vertical left line is Adjacent (Sub-line)", adjacents[0]);
        }

        [TestMethod]
        public void RightLineIsAdjacentSubLine()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(2, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(0, 1, 2, 1);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(1, adjacents.Count);
            Assert.AreEqual("Vertical right line is Adjacent (Sub-line)", adjacents[0]);
        }

        [TestMethod]
        public void BottomLineIsAdjacentSubLine()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 2, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(1, 1, 2, 1);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(1, adjacents.Count);
            Assert.AreEqual("Horizontal bottom line is Adjacent (Sub-line)", adjacents[0]);
        }

        [TestMethod]
        public void UpperLineIsAdjacentSubLine()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(2, 5, 2, 1);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(1, adjacents.Count);
            Assert.AreEqual("Horizontal upper line is Adjacent (Sub-line)", adjacents[0]);
        }

        [TestMethod]
        public void LeftLineIsAdjacentPartial()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 2, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(5, 0, 2, 3);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(1, adjacents.Count);
            Assert.AreEqual("Vertical left line is Adjacent (Partial)", adjacents[0]);
        }

        [TestMethod]
        public void UpperLineIsAdjacentPartial()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(3, 5, 4, 4);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(1, adjacents.Count);
            Assert.AreEqual("Horizontal upper line is Adjacent (Partial)", adjacents[0]);
        }

        [TestMethod]
        public void BottomLineIsAdjacentPartial()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(2, 1, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(2, 0, 6, 1);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(1, adjacents.Count);
            Assert.AreEqual("Horizontal bottom line is Adjacent (Partial)", adjacents[0]);
        }


        [TestMethod]
        public void LeftAndRightAreAdjacentSubLine()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(0, 1, 5, 2);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(2, adjacents.Count);
            Assert.AreEqual("Vertical left line is Adjacent (Sub-line)", adjacents[0]);
            Assert.AreEqual("Vertical right line is Adjacent (Sub-line)", adjacents[1]);
        }

        [TestMethod]
        public void LeftAndRightAreAdjacentPartial()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 2, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(0, 1, 5, 3);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(2, adjacents.Count);
            Assert.AreEqual("Vertical left line is Adjacent (Partial)", adjacents[0]);
            Assert.AreEqual("Vertical right line is Adjacent (Partial)", adjacents[1]);
        }

        [TestMethod]
        public void OnlyOnePointTouchingIsNotAdjacent()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 3, 3);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(3, 3, 3, 3);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(0, adjacents.Count);
        }

        [TestMethod]
        public void Rect2IsWiderThanRect1()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(1, 1, 3, 3);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(0, 0, 5, 1);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(1, adjacents.Count);
            Assert.AreEqual("Horizontal bottom line is Adjacent (Partial)", adjacents[0]);
        }

        [TestMethod]
        public void Rect2IsWiderThanRect1AndStartsInSamePoint()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(1, 1, 3, 3);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(1, 0, 5, 1);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(1, adjacents.Count);
            Assert.AreEqual("Horizontal bottom line is Adjacent (Partial)", adjacents[0]);
        }

        [TestMethod]
        public void Rect2HasSameWidthAndStartsInSamePoint()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(1, 1, 3, 3);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(1, 0, 3, 1);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(1, adjacents.Count);
            Assert.AreEqual("Horizontal bottom line is Adjacent (Proper)", adjacents[0]);
        }

        [TestMethod]
        public void Rect2IsWiderAndNotAdjacent()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(1, 1, 3, 3);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(0, 0, 6, 2);

            List<string> adjacents = rect1.FindAdjacents(rect2);

            Assert.AreEqual(0, adjacents.Count);
        }


    }

}
