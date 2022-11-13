using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RectanglesNuvalence;

namespace RectangleTest.Rectangle
{
    [TestClass]
    public class IsContained
    {
        [TestMethod]
        public void Rectangle2IsContained()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(1, 1, 3, 3);

            bool isContained = rect1.IsContained(rect2);

            Assert.AreEqual(true, isContained);
        }

        [TestMethod]
        public void RightLineIsAdjacent()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(1, 1, 4, 3);

            bool isContained = rect1.IsContained(rect2);

            Assert.AreEqual(false, isContained);
        }

        [TestMethod]
        public void Rect2IsWider()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(1, 1, 6, 3);

            bool isContained = rect1.IsContained(rect2);

            Assert.AreEqual(false, isContained);
        }

        [TestMethod]
        public void Rect2IsEqualToRect1()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);

            bool isContained = rect1.IsContained(rect2);

            Assert.AreEqual(false, isContained);
        }

        [TestMethod]
        public void Rect2DontTouchRect1()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 2, 2);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(3, 0, 2, 2);

            bool isContained = rect1.IsContained(rect2);

            Assert.AreEqual(false, isContained);
        }

        [TestMethod]
        public void Rect2IsBiggerThanRect1()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(1, 1, 2, 2);
            RectanglesNuvalence.Rectangle rect2 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);

            bool isContained = rect1.IsContained(rect2);

            Assert.AreEqual(false, isContained);
        }


    }
}
