using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aibio.Test.Fixtures;
using aibio.Units.Motors;
using NUnit.Framework;

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

        [Test]
        public void MotorActivate()
        {
            MotorFixture m = new MotorFixture();
            Point p = new Point(0, 0);

            m.Activate(0.0f, ref p);
            Assert.That(m.GetActivationValue(), Is.EqualTo(0.0f));

            m.Activate(1.0f, ref p);
            Assert.That(m.GetActivationValue(), Is.EqualTo(1.0f));

            m.Activate(1.1f, ref p);
            Assert.That(m.GetActivationValue(), Is.EqualTo(1.0f));

            m.Activate(-0.1f, ref p);
            Assert.That(m.GetActivationValue(), Is.EqualTo(-0.1f));

            m.Activate(-1.0f, ref p);
            Assert.That(m.GetActivationValue(), Is.EqualTo(-1.0f));

            m.Activate(-1.1f, ref p);
            Assert.That(m.GetActivationValue(), Is.EqualTo(-1.0f));
        }
    }

    namespace Fixtures
    {
        public class MotorFixture : Motor
        {

        }

    }
}
