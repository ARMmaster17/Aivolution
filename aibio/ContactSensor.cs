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
            public abstract class ContactSensor : Sensor
            {
                protected ContactSensor()
                {
                    
                }

                protected ContactSensor(Point sensorOffsetFromCenter)
                    : base(sensorOffsetFromCenter)
                {
                    
                }
            }
        }
    }
}
