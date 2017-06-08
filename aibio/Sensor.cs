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
                private double _impulseValue;
                
                /// <summary>
                /// Location of Sensor object relative to center position
                /// of organism.
                /// </summary>
                private Point _sensorLocation;

                protected Sensor() : base()
                {
                    _impulseValue = 0;
                }

                protected Sensor(Point sensorOffsetFromCenter) : base()
                {
                    _sensorLocation = sensorOffsetFromCenter;
                    _impulseValue = 0;
                }

                public double GetImpulse()
                {
                    return _impulseValue;
                }

                public override void Update(Point organismCenter)
                {
                    // Do sensing stuff.
                    base.Update(organismCenter);
                }

                public override void Draw(ref Graphics g, Point organismCenter)
                {
                    base.Draw(ref g, organismCenter);
                }

                public void AddImpulse(double value)
                {
                    SetImpulse(_impulseValue + value);
                }

                public void SetImpulse(double value)
                {
                    _impulseValue = Math.Max(Math.Min(value, 1.0f), 0.0f);
                }
            }
        }
    }
}
