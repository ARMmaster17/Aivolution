using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aibio.Test.Fixtures;
using aibio.Units.Motors;
using NUnit.Framework;
using System.Collections;

namespace aibio.Test
{
    [TestFixture]
    public class MotorTests
    {
        [Test]
        public void MotorInit()
        {
            MotorFixture m = new MotorFixture();
            Assert.IsNotNull(m);
        }

        [Test, TestCaseSource(typeof(MotorTestsData), nameof(MotorTestsData.MotorActivateTestCases))]
        public double MotorActivate(double activationValue)
        {
            MotorFixture m = new MotorFixture();
            Point p = new Point(0, 0);

            m.Activate(activationValue, ref p);
            return m.GetActivationValue();
        }
    }

    public class MotorTestsData
    {
        public static IEnumerable MotorActivateTestCases
        {
            get
            {
                yield return new TestCaseData(-1.1f).Returns(-1.0f);
                yield return new TestCaseData(-1.0f).Returns(-1.0f);
                yield return new TestCaseData(-0.1f).Returns(-0.1f);
                yield return new TestCaseData(0.0f).Returns(0.0f);
                yield return new TestCaseData(0.5f).Returns(0.5f);
                yield return new TestCaseData(1.0f).Returns(1.0f);
                yield return new TestCaseData(1.1f).Returns(1.0f);
            }
        }
    }

    namespace Fixtures
    {
        public class MotorFixture : Motor
        {

        }

    }
}
