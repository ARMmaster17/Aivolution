using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace aibio
{
    namespace Units
    {
        namespace Sensors
        {
            public abstract class Sensor : Biopart
            {
                /// <summary>
                /// Location of Sensor object relative to center position
                /// of organism.
                /// </summary>
                private Point _sensorLocation;

                protected Sensor() : base()
                {

                }

                protected Sensor(Point sensorOffsetFromCenter) : base()
                {
                    _sensorLocation = sensorOffsetFromCenter;
                }

                public abstract double GetImpulseValue();

                public override void Update(Point organismCenter)
                {
                    // Do sensing stuff.
                    base.Update(organismCenter);
                }

                public override void Draw(ref Graphics g, Point organismCenter)
                {
                    base.Draw(ref g, organismCenter);
                }
            }
        }
    }
}
