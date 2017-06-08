using System;
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
        public void SensorImpulse()
        {
            // Initialize test object using fixture since it's an abstract class.
            SensorFixture s = new SensorFixture();
            // Test default value.
            Assert.That(s.GetImpulse(), Is.EqualTo(0.0f));
            // Test set function.
            s.SetImpulse(0.5f);
            Assert.That(s.GetImpulse(), Is.EqualTo(0.5f));
            // Test upper and lower limits.
            s.SetImpulse(1.0f);
            Assert.That(s.GetImpulse(), Is.EqualTo(1.0f));
            s.SetImpulse(0.0f);
            Assert.That(s.GetImpulse(), Is.EqualTo(0.0f));
            // Test normalization values.
            s.SetImpulse(1.1f);
            Assert.That(s.GetImpulse(), Is.EqualTo(1.0f));
            s.SetImpulse(-0.1f);
            Assert.That(s.GetImpulse(), Is.EqualTo(0.0f));
        }
    }

    namespace Fixtures
    {
        public class SensorFixture : Sensor
        {

        }

    }
}

