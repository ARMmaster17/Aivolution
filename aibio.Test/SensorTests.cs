using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using aibio.Test.Fixtures;
using aibio.Units.Sensors;
using NUnit.Framework;

namespace aibio.Test
{
    [TestFixture]
    public class SensorTests
    {
        [Test]
        public void SensorInit()
        {
            SensorFixture s = new SensorFixture();
            Assert.IsNotNull(s);
        }

        [Test]
        public void SensorImpulseDefault()
        {
            // Initialize test object using fixture since it's an abstract class.
            SensorFixture s = new SensorFixture();
            // Test default value of Sensor class instance.
            Assert.That(s.GetImpulse(), Is.EqualTo(0.0f));
        }

        [Test, TestCaseSource(typeof(SensorTestsData), nameof(SensorTestsData.SensorTestCases))]
        public double SensorImpulse(double testImpulseValue)
        {
            // Initialize test object using fixture since it's an abstract class.
            SensorFixture s = new SensorFixture();
            // Run against given arguments.
            s.SetImpulse(testImpulseValue);
            return s.GetImpulse();
        }
    }

    public class SensorTestsData
    {
        public static IEnumerable SensorTestCases
        {
            get
            {
                yield return new TestCaseData(-0.1f).Returns(0.0f);
                yield return new TestCaseData(0.0f).Returns(0.0f);
                yield return new TestCaseData(0.5f).Returns(0.5f);
                yield return new TestCaseData(1.0f).Returns(1.0f);
                yield return new TestCaseData(1.1f).Returns(1.0f);
            }
        }
    }

    namespace Fixtures
    {
        public class SensorFixture : Sensor
        {

        }

    }
}

