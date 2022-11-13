using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RectanglesNuvalence;

namespace RectangleTest.Rectangle
{
    [TestClass]
    public class Constructor
    {
        [TestMethod]
        public void ValuesAreCorrect()
        {
            RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 5, 5);

            Assert.IsInstanceOfType(rect1, typeof(RectanglesNuvalence.Rectangle));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FirstCoordinateIsNegative()
        {
            try
            {
                RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(-1, 0, 5, 5);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Values x, y, width and height must be all positive\n", ex.Message);
                throw;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WidthIsNegative()
        {
            try
            {
                RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, -5, 5);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Values x, y, width and height must be all positive\n", ex.Message);
                throw;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WidthIsZero()
        {
            try
            {
                RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 0, 5);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Width must be greater than 0\n", ex.Message);
                throw;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void HeightIsZero()
        {
            try
            {
                RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, 0, 3, 0);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Height must be greater than 0\n", ex.Message);
                throw;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void XValuesAreBiggerThanInt32()
        {
            try
            {
                RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(Int32.MaxValue, 0, 5, 5);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("The sum of x and width is greater than the maximum allowed\n", ex.Message);
                throw;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void YValuesAreBiggerThanInt32()
        {
            try
            {
                RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(0, Int32.MaxValue, 5, 5);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("The sum of y and height is greater than the maximum allowed\n", ex.Message);
                throw;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FirstCoordinateIsNegativeAndWidthIsZero()
        {
            try
            {
                RectanglesNuvalence.Rectangle rect1 = new RectanglesNuvalence.Rectangle(-1, 0, 0, 5);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Values x, y, width and height must be all positive\nWidth must be greater than 0\n", ex.Message);
                throw;
            }

        }


    }
}
