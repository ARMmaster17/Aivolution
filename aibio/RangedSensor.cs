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
            public abstract class RangedSensor : Sensor
            {
                private bool _drawSensorField;
                private float _sensorDirection;

                protected RangedSensor()
                {
                    _sensorDirection = 0.0f;
                }

                protected RangedSensor(bool drawSensorField)
                {
                    _drawSensorField = drawSensorField;
                    _sensorDirection = 0.0f;
                }

                protected RangedSensor(bool drawSensorField, Point sensorOffsetFromCenter)
                    : base(sensorOffsetFromCenter)
                {
                    _drawSensorField = drawSensorField;
                    _sensorDirection = 0.0f;
                }

                protected RangedSensor(bool drawSensorField, Point senorOffsetFromCenter, float sensorAngle)
                    : base(senorOffsetFromCenter)
                {
                    _drawSensorField = drawSensorField;
                    _sensorDirection = sensorAngle;
                }
            }
        }
    }
}
